﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;

namespace mon_pass
{
    

    public partial class Form1 : Form
    {
        int pagenumber = 1;
        int pagenumber_2 = 1;
        int pagenumber_3 = 1;
        IPagedList<main> list;
        IPagedList<main_corp> list1;
        IPagedList<one_pass> list2;

        string or_and;

        

        bool row_added;

        List<string> fi_list = new List<string>();

        public static bool old_che_2;
        public static bool old_che_1;

        public Form1()
        {
            InitializeComponent();
            panel2.Dock = DockStyle.Fill;
        }


        public async Task<IPagedList<main_corp>> getpage_update_grid_corp(int pagenumber_2 = 1, int pagesize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (mainEntities dd = new mainEntities())
                {
                    //Int32 oiyuggb = dd.mains.OrderBy(p => p.id).Count();

                    double oiyuggb1 = Math.Ceiling((double)dd.main_corp.OrderBy(p => p.id).Count() / 50);

                    //oiyuggb1 = oiyuggb1 / pagesize;
                    Int32 a = Convert.ToInt32(oiyuggb1);
                    if (oiyuggb1 == 0) { oiyuggb1 = 1; }
                    pagenumber_2 = a;
                    return dd.main_corp.OrderBy(p => p.id).ToPagedList(a, pagesize);


                }

            });
        }


        public async Task<IPagedList<one_pass>> getpage_update_grid_one_pass(int pagenumber_3 = 1, int pagesize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (mainEntities dd = new mainEntities())
                {
                    //Int32 oiyuggb = dd.mains.OrderBy(p => p.id).Count();

                    double oiyuggb1 = Math.Ceiling((double)dd.one_pass.OrderBy(p => p.id).Count() / 50);

                    //oiyuggb1 = oiyuggb1 / pagesize;
                    Int32 a = Convert.ToInt32(oiyuggb1);
                    if (oiyuggb1 == 0) { oiyuggb1 = 1; }
                    pagenumber_3 = a;
                    return dd.one_pass.OrderBy(p => p.id).ToPagedList(a, pagesize);


                }

            });
        }


        public async Task<IPagedList<main>> getpage_update_grid(int pagenumber = 1, int pagesize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (mainEntities dd = new mainEntities())
                {
                    //Int32 oiyuggb = dd.mains.OrderBy(p => p.id).Count();

                    double oiyuggb1 = Math.Ceiling((double)dd.mains.OrderBy(p => p.id).Count() / 50);

                    //oiyuggb1 = oiyuggb1 / pagesize;
                    Int32 a = Convert.ToInt32(oiyuggb1);
                    if (oiyuggb1 == 0) { oiyuggb1 = 1; }
                    pagenumber = a;
                    return dd.mains.OrderBy(p => p.id).ToPagedList(a, pagesize);

                    
                }

            });
        }

        

        public async Task<IPagedList<main_corp>> getpage_corp(int pagenumber_2 = 1, int pagesize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (mainEntities dd = new mainEntities())
                {
                    return dd.main_corp.OrderBy(p => p.id).ToPagedList(pagenumber_2, pagesize);
                }

            });
        }

        public async Task<IPagedList<main>> getpage(int pagenumber = 1, int pagesize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (mainEntities dd = new mainEntities())
                {
                    return dd.mains.OrderBy(p => p.id).ToPagedList(pagenumber, pagesize);
                }
            
            });
        }


        public async Task<IPagedList<one_pass>> getpage_one_pass(int pagenumber_3 = 1, int pagesize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (mainEntities dd = new mainEntities())
                {
                    return dd.one_pass.OrderBy(p => p.id).ToPagedList(pagenumber_3, pagesize);
                }

            });
        }


        public async Task<IPagedList<main>> getpage_filter_all(int pagenumber = 1, int pagesize = 50)
        {

            return await Task.Factory.StartNew(() =>
            {
                using (mainEntities ff = new mainEntities())
                {
                    return ff.mains.SqlQuery("select * from main ").ToPagedList(pagenumber, pagesize);

                }
            });

        }


        public async Task<IPagedList<one_pass>> getpage_filter_one_pass(string filter, int pagenumber_3 = 1, int pagesize = 50)
        {

            return await Task.Factory.StartNew(() =>
            {

                using (mainEntities ff = new mainEntities())
                {
                    return ff.one_pass.SqlQuery("select * from one_pass where " + filter).ToPagedList(pagenumber_3, pagesize);

                }

            });
        }

        public async Task<IPagedList<one_pass>> getpage_filter_all_one_pass(int pagenumber_3 = 1, int pagesize = 50)
        {

            return await Task.Factory.StartNew(() =>
            {
                using (mainEntities ff = new mainEntities())
                {
                    return ff.one_pass.SqlQuery("select * from one_pass ").ToPagedList(pagenumber_3, pagesize);

                }
            });

        }


        public async Task<IPagedList<main_corp>> getpage_filter_corp(string filter, int pagenumber_2 = 1, int pagesize = 50)
        {

            return await Task.Factory.StartNew(() =>
            {

                using (mainEntities ff = new mainEntities())
                {
                    return ff.main_corp.SqlQuery("select * from main_corp where " + filter).ToPagedList(pagenumber_2, pagesize);

                }

            });
        }

        public async Task<IPagedList<main_corp>> getpage_filter_all_corp(int pagenumber_2 = 1, int pagesize = 50)
        {

            return await Task.Factory.StartNew(() =>
            {
                using (mainEntities ff = new mainEntities())
                {
                    return ff.main_corp.SqlQuery("select * from main_corp ").ToPagedList(pagenumber_2, pagesize);
                    
                }
            });

        }
                

        public async Task<IPagedList<main>> getpage_filter(string filter,int pagenumber = 1, int pagesize = 50)
        {
            
            return await Task.Factory.StartNew(() =>
            {

                

                using (mainEntities ff = new mainEntities())
                {
                    return ff.mains.SqlQuery("select * from main where "+filter).ToPagedList(pagenumber, pagesize);
                    
                }

            });
        }

        public void relocate_filter_text_box_corp()
        {
            try
            {
                //Control temp;

                var items = dataGridView3.Controls;
                //var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, 8));

                for (int i = 0; i < dataGridView3.Columns.Count; i++)
                {

                    //dataGridView3.Enabled = false;
                    if (dataGridView3.Columns[i].Visible)
                    {

                        //temp = dataGridView3.Controls[i];
                        //temp = dataGridView3.Controls["TxtBoxVol_" + i.ToString()];
                        var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, i));

                        Rectangle dd = dataGridView3.GetCellDisplayRectangle(i, -1, true);
                        
                        if (temp is MaskedTextBox)
                        {

                            var temp1 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox_corp_1"));
                            temp1.Width = (dataGridView3.Columns[i].Width / 2) - 8;
                            temp1.Location = new Point(dd.X + 3, dd.Y + 48);
                            var temp2 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox_corp_2"));
                            temp2.Width = (dataGridView3.Columns[i].Width / 2) - 8;
                            temp2.Location = new Point((dd.X + temp2.Width + 9) + 3, dd.Y + 48);
                        }
                        else
                        {
                            if (dataGridView3.Columns[i].DataPropertyName == "qty")
                            {
                                //label4.Text = "ჯამი: 5555";
                                label4.Width = dataGridView3.Columns[i].Width;
                                label4.Location= new Point(dd.X -55, label4.Location.Y);
                            }
                            temp.Width = dataGridView3.Columns[i].Width - 8;
                            temp.Location = new Point(dd.X + 3, dd.Y + 48);
                        }


                        Application.DoEvents();

                        //if (temp is TextBox)
                        //{
                        //temp.Width = dataGridView3.Columns[i].Width - 8;
                        //temp.Location = new Point(dd.X + 3, dd.Y + 48);

                        //}

                        //if (temp is CheckBox)
                        //{

                        //    temp.Location = new Point((dd.X + (dd.Width / 2)) - 7, dd.Y + 22);
                        //}
                    }
                }


            }
            catch (Exception ex)
            {
                ///string ppp = ex.Message;
            }

        }


        public void relocate_filter_text_box_one_pass()
        {
            try
            {
                //Control temp;

                var items = dataGridView2.Controls;
                //var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, 8));

                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {

                    //dataGridView3.Enabled = false;
                    if (dataGridView2.Columns[i].Visible)
                    {

                        //temp = dataGridView3.Controls[i];
                        //temp = dataGridView3.Controls["TxtBoxVol_" + i.ToString()];
                        var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, i));

                        Rectangle dd = dataGridView2.GetCellDisplayRectangle(i, -1, true);

                        if (temp is MaskedTextBox)
                        {
                            if (temp.Name == "maskedTextBox_one_pass_time_1")
                            {
                                temp.Width = dataGridView2.Columns[i].Width - 8;
                                temp.Location = new Point(dd.X + 3, dd.Y + 48);
                            }
                            else
                            {
                                var temp1 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox_one_pass_1"));
                                temp1.Width = (dataGridView2.Columns[i].Width / 2) - 8;
                                temp1.Location = new Point(dd.X + 3, dd.Y + 48);
                                var temp2 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox_one_pass_2"));
                                temp2.Width = (dataGridView2.Columns[i].Width / 2) - 8;
                                temp2.Location = new Point((dd.X + temp2.Width + 9) + 3, dd.Y + 48);
                            }
                            
                        }
                        else
                        {                            
                            temp.Width = dataGridView2.Columns[i].Width - 8;
                            temp.Location = new Point(dd.X + 3, dd.Y + 48);
                        }


                        Application.DoEvents();

                        //if (temp is TextBox)
                        //{
                        //temp.Width = dataGridView3.Columns[i].Width - 8;
                        //temp.Location = new Point(dd.X + 3, dd.Y + 48);

                        //}

                        //if (temp is CheckBox)
                        //{

                        //    temp.Location = new Point((dd.X + (dd.Width / 2)) - 7, dd.Y + 22);
                        //}
                    }
                }


            }
            catch (Exception ex)
            {
                ///string ppp = ex.Message;
            }

        }

        public void relocate_filter_text_box()
        {
            try
            {
                //Control temp;

                var items = dataGridView1.Controls;
                //var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, 8));

                //for (int i = 0; i < items.Count; i++)
                //{
                //    if (items[i] is TextBox)
                //    {

                //    }

                //}

                Application.DoEvents();

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {

                    //dataGridView3.Enabled = false;
                    if (dataGridView1.Columns[i].Visible)
                    {

                        //temp = dataGridView3.Controls[i];
                        //temp = dataGridView3.Controls["TxtBoxVol_" + i.ToString()];
                        var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, i));



                        Rectangle dd = dataGridView1.GetCellDisplayRectangle(i, -1, false);

                        if (temp is MaskedTextBox)
                        {
                            var temp1 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox1"));
                            temp1.Width = (dataGridView1.Columns[i].Width/2) - 8;
                            temp1.Location = new Point(dd.X + 3, dd.Y + 48);
                            temp1 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox2"));
                            temp1.Width = (dataGridView1.Columns[i].Width/2) - 8;
                            temp1.Location = new Point((dd.X + temp1.Width + 9) + 3, dd.Y + 48);
                        }
                        else
                        {
                            if (dataGridView1.Columns[i].DataPropertyName == "qty")
                            {
                                //label3.Text = "ჯამი: 5555";
                                label3.Width = dataGridView1.Columns[i].Width;
                                label3.Location = new Point(dd.X - 55, label3.Location.Y);

                            }
                            temp.Width = dataGridView1.Columns[i].Width - 8;
                            temp.Location = new Point(dd.X + 3, dd.Y + 48);
                        }

                        
                        ////if (temp is TextBox)
                        ////{
                        //    temp.Width = dataGridView1.Columns[i].Width - 8;
                        //    temp.Location = new Point(dd.X + 3, dd.Y + 48);

                        ////}

                        //if (temp is CheckBox)
                        //{

                        //    temp.Location = new Point((dd.X + (dd.Width / 2)) - 7, dd.Y + 22);
                        //}
                    }
                }


            }
            catch
            {

            }

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.DataTable3' table. You can move, or remove it, as needed.
            //this.dataTable3TableAdapter.Fill(this.dataSet2.DataTable3);
            // TODO: This line of code loads data into the 'dataSet2.DataTable2' table. You can move, or remove it, as needed.
           // this.dataTable2TableAdapter.Fill(this.dataSet2.DataTable2);
            // TODO: This line of code loads data into the 'dataSet2.DataTable1' table. You can move, or remove it, as needed.
            //this.dataTable1TableAdapter.Fill(this.dataSet2.DataTable1);
            // TODO: This line of code loads data into the 'dataSet21.DataTable1' table. You can move, or remove it, as needed.
            //this.dataTable1TableAdapter1.Fill(this.dataSet21.DataTable1);
            // TODO: This line of code loads data into the 'dataSet1.DataTable1' table. You can move, or remove it, as needed.
            //this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);
            // TODO: This line of code loads data into the 'dataSet11.DataTable3' table. You can move, or remove it, as needed.
            //this.dataTable3TableAdapter.Fill(this.dataSet11.DataTable3);
            or_and = " or ";
            // TODO: This line of code loads data into the 'dataSet1.DataTable1' table. You can move, or remove it, as needed.
            //this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1,1);
            //this.dataTable2TableAdapter.Fill(this.dataSet1.DataTable2);

            // TODO: This line of code loads data into the 'dataSet1.DataTable2' table. You can move, or remove it, as needed.
            //this.dataTable2TableAdapter.Fill(this.dataSet1.DataTable2);

            Type dgvType1 = dataGridView1.GetType();
            PropertyInfo pi1 = dgvType1.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi1.SetValue(dataGridView1, true, null);

            Type dgvType2 = dataGridView3.GetType();
            PropertyInfo pi2 = dgvType2.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi2.SetValue(dataGridView3, true, null);

            Type dgvType3 = dataGridView2.GetType();
            PropertyInfo pi3 = dgvType3.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi3.SetValue(dataGridView2, true, null);


            list = await getpage();
            dataGridView1.DataSource = list.ToList();

            list1 = await getpage_corp();
            dataGridView3.DataSource = list1.ToList();

            list2 = await getpage_one_pass();
            dataGridView2.DataSource = list2.ToList();

            if (list.PageCount == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button7.Enabled = false;
            }
            else
            {
                if (list.HasNextPage)
                {
                    button2.Enabled = true;
                    button4.Enabled = true;
                }

                if (list.HasPreviousPage)
                {
                    button1.Enabled = true;
                    button7.Enabled = true;
                }
            }

            if (list1.PageCount == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button7.Enabled = false;
            }
            else
            {
                if (list1.HasNextPage)
                {
                    button2.Enabled = true;
                    button4.Enabled = true;
                }

                if (list1.HasPreviousPage)
                {
                    button1.Enabled = true;
                    button7.Enabled = true;
                }
            }

            if (list2.PageCount == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button7.Enabled = false;
            }
            else
            {
                if (list2.HasNextPage)
                {
                    button2.Enabled = true;
                    button4.Enabled = true;
                }

                if (list2.HasPreviousPage)
                {
                    button1.Enabled = true;
                    button7.Enabled = true;
                }
            }



            try
            {
                label3.Text = "ჯამი: " + dataTable2TableAdapter.ScalarQuery_sum_main().ToString();
                label4.Text = "ჯამი: " + dataTable3TableAdapter.ScalarQuery_sum_main_corp().ToString();
            }
            catch
            {
                label3.Text = "ჯამი: 0";
                label4.Text = "ჯამი: 0";
            }
            

            label3.Width = dataGridView1.Columns[9].Width;
            Rectangle dd = dataGridView1.GetCellDisplayRectangle(9, -1, false);
            label3.Location = new Point(dd.X - 55, label3.Location.Y);
            label4.Width = dataGridView3.Columns[9].Width;
            label4.Location = new Point(dd.X - 55, label4.Location.Y);

            label3.Visible = true;
            label4.Visible = true;

            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber, list.PageCount);
            
            //button1.Enabled = false;
            //button2.Enabled = false;

            //if (pagenumber == list.PageCount)
            //{
            //    button2.Enabled = false;
            //    button1.Enabled = false;
            //}

            //if (pagenumber <= list.PageCount)
            //{
            //    button2.Enabled = true;
            //    button1.Enabled = false;
            //}

            

            filter_boxses();
            filter_boxses_corp();
            filter_boxses_one_pass();
            panel2.Visible = false;
            //label3.Text = "ჯამი: 5555";
            
        }

        private async  void button1_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 0)
            {
                if (list.HasPreviousPage)
                {
                    pagenumber = pagenumber - 1;
                    list = await getpage(pagenumber);
                    dataGridView1.DataSource = list.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber, list.PageCount);
                    button2.Enabled = true;
                    button4.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                    button7.Enabled = false;
                }
                if (!list.HasPreviousPage)
                {
                    button1.Enabled = false;
                    button7.Enabled = false;
                }
                relocate_filter_text_box();
            }

            if (tabControl1.SelectedIndex == 1)
            {
                if (list1.HasPreviousPage)
                {
                    pagenumber_2 = pagenumber_2 - 1;
                    list1 = await getpage_corp(pagenumber_2);
                    dataGridView3.DataSource = list1.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_2, list1.PageCount);
                    button2.Enabled = true;
                    button4.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                    button7.Enabled = false;
                }
                if (!list1.HasPreviousPage)
                {
                    button1.Enabled = false;
                    button7.Enabled = false;
                }
                
                relocate_filter_text_box_corp();
            }

            if (tabControl1.SelectedIndex == 2)
            {
                if (list2.HasPreviousPage)
                {
                    pagenumber_3 = pagenumber_3 - 1;
                    list2 = await getpage_one_pass(pagenumber_3);
                    dataGridView2.DataSource = list2.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_3, list1.PageCount);
                    button2.Enabled = true;
                    button4.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                    button7.Enabled = false;
                }
                if (!list2.HasPreviousPage)
                {
                    button1.Enabled = false;
                    button7.Enabled = false;
                }
                relocate_filter_text_box_one_pass();
            }

            
            

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (list.HasNextPage)
                {
                    pagenumber = pagenumber + 1;
                    list = await getpage(pagenumber);
                    dataGridView1.DataSource = list.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber, list.PageCount);
                    button1.Enabled = true;
                    button7.Enabled = true;

                }
                else
                {
                    button2.Enabled = false;
                    button4.Enabled = false;
                }
                if (!list.HasNextPage)
                {
                    button2.Enabled = false;
                    button4.Enabled = false;
                }
                relocate_filter_text_box();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                if (list1.HasNextPage)
                {
                    pagenumber_2 = pagenumber_2 + 1;
                    list1 = await getpage_corp(pagenumber_2);
                    dataGridView3.DataSource = list1.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_2, list1.PageCount);
                    button1.Enabled = true;
                    button7.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                    button7.Enabled = false;
                }
                if (!list1.HasNextPage)
                {
                    button2.Enabled = false;
                    button4.Enabled = false;                    
                }
                
                relocate_filter_text_box_corp();
            }

            if (tabControl1.SelectedIndex == 2)
            {
                if (list2.HasNextPage)
                {
                    pagenumber_3 = pagenumber_3 + 1;
                    list2 = await getpage_one_pass(pagenumber_3);
                    dataGridView2.DataSource = list1.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_3, list1.PageCount);
                    button1.Enabled = true;
                    button7.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                    button7.Enabled = false;
                }
                if (!list2.HasNextPage)
                {
                    button2.Enabled = false;
                    button7.Enabled = false;
                }
                relocate_filter_text_box_one_pass();
            }

            
            

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            relocate_filter_text_box();
            relocate_filter_text_box_corp();
            relocate_filter_text_box_one_pass();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            //try
            //{
            //    var row = this.dataGridView1.CurrentRow;
            //    string a = row.Cells[0].EditedFormattedValue.ToString();

            //    if (a != "")
            //    {
            //        this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1, row.Cells[0].Value); 
            //    }

               
            //}
            //catch

            //    { }            
            
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo myHitTestUp = dataGridView1.HitTest(e.X, e.Y);
            if (myHitTestUp.Type == DataGridViewHitTestType.ColumnHeader)
            {

                //dataGridView3.Controls.Clear();



                foreach (Control item in dataGridView1.Controls.OfType<TextBox>())
                {
                    item.Visible = false;
                    //item.Enabled = false;
                    //dataGridView3.Controls[item.inde].Visible = false;
                }

                //for (int i = 0; i < dataGridView3.Controls.Count; i++)
                //{
                //    dataGridView3.Controls.Remove["TxtBoxVol_" + i.ToString()];
                //}



                Application.DoEvents();
                relocate_filter_text_box();
                Application.DoEvents();

                foreach (Control item in dataGridView1.Controls.OfType<TextBox>())
                {
                    item.Visible = true;
                    //item.Enabled = true;
                    //dataGridView3.Controls[item.inde].Visible = false;
                }

                //for (int i = 0; i < dataGridView3.Controls.Count; i++)
                //{
                //    dataGridView3.Controls[i].Visible = true;
                //}
            }
        }



        
        public async void FFilter_grid_one_pass()
        {
            string filter_text = "";
            fi_list.Clear();
            var items = dataGridView2.Controls;
            //var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, 8));

            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {

                //dataGridView3.Enabled = false;
                if (dataGridView2.Columns[i].Visible)
                {

                    //temp = dataGridView3.Controls[i];
                    //temp = dataGridView3.Controls["TxtBoxVol_" + i.ToString()];
                    var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, i));

                    if (temp is TextBox)
                    {
                        if (!string.IsNullOrWhiteSpace(temp.Text))
                        {
                            //var isNumeric = int.TryParse(temp.Text, out int n);
                            //if (dataGridView1.Columns[i].DataPropertyName == "plc_refresh_second" || dataGridView1.Columns[i].DataPropertyName == "plc_only_change_precision")
                            //{
                            //    filter_text = filter_text + dataGridView1.Columns[i].DataPropertyName + "=" + temp.Text + or_and;
                            //}
                            //else
                            //{
                            //    filter_text = filter_text + dataGridView1.Columns[i].DataPropertyName + " LIKE '%" + temp.Text + "%'" + or_and;
                            //}
                            filter_text = filter_text + dataGridView2.Columns[i].DataPropertyName + " LIKE '%" + temp.Text + "%'" + or_and;
                        }

                    }

                    if (temp is MaskedTextBox)
                    {
                        if (temp.Name == "maskedTextBox_one_pass_time_1")
                        {
                            if (((temp.Text != "  :  ") && (temp.Text.Length == 5)) )
                            {
                                DateTime dt = DateTime.Parse(temp.Text);
                                string datestring = dt.ToString("HH:mm");
                                filter_text = filter_text + "strftime('%H:%M', ttime)='" + datestring + "'" + or_and;
                            }
                            //SELECT strftime('%H:%M:%S',ttime) FROM one_pass where strftime('%H:%M',ttime) between '22:16' and '22:16'
                        }
                        //else
                        //{

                            


                        //    bool twice = false;

                        //    if (temp.Name == "maskedTextBox_one_pass_1")
                        //    {
                        //        if ((temp.Text != "  .  .") && (temp.Text.Length == 10))
                        //        {
                        //            try
                        //            {
                        //                DateTime dt = DateTime.Parse(temp.Text);
                        //                string datestring = dt.ToString("yyyy-MM-dd");
                        //                filter_text = filter_text + dataGridView2.Columns[i].DataPropertyName + " ='" + datestring + "'" + or_and;
                        //                twice = true;
                        //            }
                        //            catch
                        //            {

                        //            }

                        //        }
                        //    }

                        //    if (temp.Name == "maskedTextBox_one_pass_2")
                        //    {
                        //        if ((temp.Text != "  .  .") && (temp.Text.Length == 10))
                        //        {
                        //            try
                        //            {
                        //                DateTime dt = DateTime.Parse(temp.Text);
                        //                string datestring = dt.ToString("yyyy-MM-dd");
                        //                if (twice)
                        //                {
                        //                    filter_text = filter_text + dataGridView2.Columns[i].DataPropertyName + " ='" + datestring + "'" + or_and;
                        //                }
                        //                else
                        //                {
                        //                    filter_text = filter_text + dataGridView2.Columns[i].DataPropertyName + " ='" + datestring + "'" + or_and;
                        //                }
                                        
                        //            }
                        //            catch
                        //            {

                        //            }

                        //        }
                        //    }
                            

                            

                            
                        //}
                        

                    }


                }
            }

            DateTime dateTime_;

            var temp1 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox_one_pass_1"));            
            var temp2 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox_one_pass_2"));

            if (((temp1.Text != "  .  .") && (temp1.Text.Length == 10)) && ((temp2.Text != "  .  .") && (temp2.Text.Length == 10)))
            {
                if (DateTime.TryParseExact(temp1.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime_) && DateTime.TryParseExact(temp2.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime_))
                {
                    DateTime dt1 = DateTime.Parse(temp1.Text);
                    DateTime dt2 = DateTime.Parse(temp2.Text);

                    string datestring1 = dt1.ToString("yyyy-MM-dd")+ " 00:00:00";
                    string datestring2 = dt2.ToString("yyyy-MM-dd")+ " 00:00:00";

                    int result = DateTime.Compare(dt1, dt2);

                    if (result < 0)
                        filter_text = filter_text + "("+dataGridView2.Columns[8].DataPropertyName + "  between '" + datestring1 + "' and '"+ datestring2+"')" + or_and;
                    else if (result == 0)
                        filter_text = filter_text + "(" + dataGridView2.Columns[8].DataPropertyName + "  between '" + datestring1 + "' and '" + datestring2 + "')" + or_and;
                    else
                        filter_text = filter_text + "(" + dataGridView2.Columns[8].DataPropertyName + "  between '" + datestring2 + "' and '" + datestring1 + "')" + or_and;
                    
                }
            }
            else
            {
                if (((temp1.Text != "  .  .") && (temp1.Text.Length == 10)))
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(temp1.Text);
                        string datestring = dt.ToString("yyyy-MM-dd");
                        filter_text = filter_text + dataGridView2.Columns[8].DataPropertyName + " ='" + datestring + " 00:00:00'" + or_and;
                    }
                    catch
                    {

                    }
                }

                if (((temp2.Text != "  .  .") && (temp2.Text.Length == 10)))
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(temp2.Text);
                        string datestring = dt.ToString("yyyy-MM-dd");
                        filter_text = filter_text + dataGridView2.Columns[8].DataPropertyName + " ='" + datestring + " 00:00:00'" + or_and;
                    }
                    catch
                    {

                    }
                }
            }




            if (filter_text.Length > 0)
            {
                if (filter_text.Contains(" or ") || filter_text.Contains(" and "))
                {
                    filter_text = filter_text.Substring(0, filter_text.Length - 4);
                }

                list2 = await getpage_filter_one_pass(filter_text);
                dataGridView2.DataSource = list2.ToList();
            }
            else
            {
                list2 = await getpage_filter_all_one_pass();
                dataGridView2.DataSource = list2.ToList();
            }



            //dataGridView1.Refresh();
            //.DefaultView.RowFilter = string.Format("Field = '{0}'", textBoxFilter.Text);
            return;
            if (!string.IsNullOrWhiteSpace(filter_text))
            {
                filter_text = filter_text.Substring(0, filter_text.Length - 5);
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filter_text;
            }
            else
            {
                (dataGridView1.DataSource as BindingSource).Filter = "";
            }


            dataGridView1.Refresh();
        }

        public async void FFilter_grid_corp()
        {
            string filter_text = "";
            fi_list.Clear();
            var items = dataGridView3.Controls;
            //var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, 8));

            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {

                //dataGridView3.Enabled = false;
                if (dataGridView3.Columns[i].Visible)
                {

                    //temp = dataGridView3.Controls[i];
                    //temp = dataGridView3.Controls["TxtBoxVol_" + i.ToString()];
                    var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, i));

                    if (temp is TextBox)
                    {
                        if (!string.IsNullOrWhiteSpace(temp.Text))
                        {
                            //var isNumeric = int.TryParse(temp.Text, out int n);
                            //if (dataGridView1.Columns[i].DataPropertyName == "plc_refresh_second" || dataGridView1.Columns[i].DataPropertyName == "plc_only_change_precision")
                            //{
                            //    filter_text = filter_text + dataGridView1.Columns[i].DataPropertyName + "=" + temp.Text + or_and;
                            //}
                            //else
                            //{
                            //    filter_text = filter_text + dataGridView1.Columns[i].DataPropertyName + " LIKE '%" + temp.Text + "%'" + or_and;
                            //}
                            filter_text = filter_text + dataGridView3.Columns[i].DataPropertyName + " LIKE '%" + temp.Text + "%'" + or_and;
                        }

                    }

                    //if (temp is MaskedTextBox)
                    //{
                    //    if ((temp.Text != "  .  .") && (temp.Text.Length == 10))
                    //    {
                    //        try
                    //        {
                    //            DateTime dt = DateTime.Parse(temp.Text);
                    //            string datestring = dt.ToString("yyyy-MM-dd");
                    //            filter_text = filter_text + dataGridView3.Columns[i].DataPropertyName + " ='" + datestring + "'" + or_and;
                    //        }
                    //        catch
                    //        {

                    //        }

                    //    }

                        


                    //}


                }
            }


            DateTime dateTime_;

            var temp1 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox_corp_1"));
            var temp2 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox_corp_2"));

            if (((temp1.Text != "  .  .") && (temp1.Text.Length == 10)) && ((temp2.Text != "  .  .") && (temp2.Text.Length == 10)))
            {
                if (DateTime.TryParseExact(temp1.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime_) && DateTime.TryParseExact(temp2.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime_))
                {
                    DateTime dt1 = DateTime.Parse(temp1.Text);
                    DateTime dt2 = DateTime.Parse(temp2.Text);

                    string datestring1 = dt1.ToString("yyyy-MM-dd") + " 00:00:00";
                    string datestring2 = dt2.ToString("yyyy-MM-dd") + " 00:00:00";

                    int result = DateTime.Compare(dt1, dt2);

                    if (result < 0)
                        filter_text = filter_text + "(" + dataGridView2.Columns[8].DataPropertyName + "  between '" + datestring1 + "' and '" + datestring2 + "')" + or_and;
                    else if (result == 0)
                        filter_text = filter_text + "(" + dataGridView2.Columns[8].DataPropertyName + "  between '" + datestring1 + "' and '" + datestring2 + "')" + or_and;
                    else
                        filter_text = filter_text + "(" + dataGridView2.Columns[8].DataPropertyName + "  between '" + datestring2 + "' and '" + datestring1 + "')" + or_and;

                }
            }
            else
            {
                if (((temp1.Text != "  .  .") && (temp1.Text.Length == 10)))
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(temp1.Text);
                        string datestring = dt.ToString("yyyy-MM-dd");
                        filter_text = filter_text + dataGridView2.Columns[8].DataPropertyName + " ='" + datestring + " 00:00:00'" + or_and;
                    }
                    catch
                    {

                    }
                }

                if (((temp2.Text != "  .  .") && (temp2.Text.Length == 10)))
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(temp2.Text);
                        string datestring = dt.ToString("yyyy-MM-dd");
                        filter_text = filter_text + dataGridView2.Columns[8].DataPropertyName + " ='" + datestring + " 00:00:00'" + or_and;
                    }
                    catch
                    {

                    }
                }
            }

            if (filter_text.Length > 0)
            {
                if (filter_text.Contains(" or ") || filter_text.Contains(" and "))
                {
                    filter_text = filter_text.Substring(0, filter_text.Length - 4);
                }

                list1 = await getpage_filter_corp(filter_text);
                dataGridView3.DataSource = list1.ToList();
            }
            else
            {
                list1 = await getpage_filter_all_corp();
                dataGridView3.DataSource = list1.ToList();
            }



            //dataGridView1.Refresh();
            //.DefaultView.RowFilter = string.Format("Field = '{0}'", textBoxFilter.Text);
            return;
            if (!string.IsNullOrWhiteSpace(filter_text))
            {
                filter_text = filter_text.Substring(0, filter_text.Length - 5);
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filter_text;
            }
            else
            {
                (dataGridView1.DataSource as BindingSource).Filter = "";
            }


            dataGridView1.Refresh();
        }

        public async void FFilter_grid()
        {
            string filter_text = "";
            fi_list.Clear();
            var items = dataGridView1.Controls;
            //var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, 8));

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {

                //dataGridView3.Enabled = false;
                if (dataGridView1.Columns[i].Visible)
                {

                    //temp = dataGridView3.Controls[i];
                    //temp = dataGridView3.Controls["TxtBoxVol_" + i.ToString()];
                    var temp = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, i));

                    if (temp is TextBox)
                    {
                        if (!string.IsNullOrWhiteSpace(temp.Text))
                        {
                            //var isNumeric = int.TryParse(temp.Text, out int n);
                            //if (dataGridView1.Columns[i].DataPropertyName == "plc_refresh_second" || dataGridView1.Columns[i].DataPropertyName == "plc_only_change_precision")
                            //{
                            //    filter_text = filter_text + dataGridView1.Columns[i].DataPropertyName + "=" + temp.Text + or_and;
                            //}
                            //else
                            //{
                            //    filter_text = filter_text + dataGridView1.Columns[i].DataPropertyName + " LIKE '%" + temp.Text + "%'" + or_and;
                            //}
                            filter_text = filter_text + dataGridView1.Columns[i].DataPropertyName + " LIKE '%" + temp.Text + "%'" + or_and;
                        }

                    }

                    //if (temp is  MaskedTextBox)
                    //{
                    //    if ((temp.Text!="  .  .") && (temp.Text.Length==10))
                    //    {
                    //        try
                    //        {
                    //            DateTime dt = DateTime.Parse(temp.Text);
                    //            string datestring = dt.ToString("yyyy-MM-dd");
                    //            filter_text = filter_text + dataGridView1.Columns[i].DataPropertyName + " ='" + datestring + "'" + or_and;
                    //        }
                    //        catch
                    //        {
                               
                    //        }
                            
                    //    }
                            
                    //    ////if (((CheckBox)temp).Checked)
                    //    ////{
                    //    //if (dataGridView1.Columns[i].Name == "plc_only_change")
                    //    //{
                    //    //    if (((DateTimePicker)temp).Checked)
                    //    //    {
                    //    //        filter_text = filter_text + dataGridView1.Columns[i].Name + " =1" + or_and;
                    //    //    }
                    //    //    else
                    //    //    {
                    //    //        if (old_che_1 != ((CheckBox)temp).Checked)
                    //    //        {
                    //    //            filter_text = filter_text + dataGridView1.Columns[i].Name + " =1" + or_and;
                    //    //        }
                    //    //        old_che_1 = ((CheckBox)temp).Checked;
                    //    //    }

                    //    //}

                    //    //if (dataGridView1.Columns[i].Name == "plc_active")
                    //    //{
                    //    //    if (((CheckBox)temp).Checked)
                    //    //    {
                    //    //        filter_text = filter_text + dataGridView1.Columns[i].Name + " =1" + or_and;
                    //    //    }
                    //    //    else
                    //    //    {
                    //    //        if (old_che_2 != ((CheckBox)temp).Checked)
                    //    //        {
                    //    //            filter_text = filter_text + dataGridView1.Columns[i].Name + " =1" + or_and;
                    //    //        }
                    //    //        old_che_2 = ((CheckBox)temp).Checked;
                    //    //    }
                    //    //}


                    //    //}
                    //    //else
                    //    //{
                    //    //    filter_text = filter_text + dataGridView3.Columns[i].Name + " =0 or ";
                    //    //}



                    //}


                }
            }

            //dataTable2BindingSource.Filter = "pass_n" + " LIKE '%" + "3" + "%'";

            DateTime dateTime_;

            var temp1 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox1"));
            var temp2 = items.Cast<Control>().FirstOrDefault(control => String.Equals(control.Name, "maskedTextBox2"));

            if (((temp1.Text != "  .  .") && (temp1.Text.Length == 10)) && ((temp2.Text != "  .  .") && (temp2.Text.Length == 10)))
            {
                if (DateTime.TryParseExact(temp1.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime_) && DateTime.TryParseExact(temp2.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime_))
                {
                    DateTime dt1 = DateTime.Parse(temp1.Text);
                    DateTime dt2 = DateTime.Parse(temp2.Text);

                    string datestring1 = dt1.ToString("yyyy-MM-dd") + " 00:00:00";
                    string datestring2 = dt2.ToString("yyyy-MM-dd") + " 00:00:00";

                    int result = DateTime.Compare(dt1, dt2);

                    if (result < 0)
                        filter_text = filter_text + "(" + dataGridView2.Columns[8].DataPropertyName + "  between '" + datestring1 + "' and '" + datestring2 + "')" + or_and;
                    else if (result == 0)
                        filter_text = filter_text + "(" + dataGridView2.Columns[8].DataPropertyName + "  between '" + datestring1 + "' and '" + datestring2 + "')" + or_and;
                    else
                        filter_text = filter_text + "(" + dataGridView2.Columns[8].DataPropertyName + "  between '" + datestring2 + "' and '" + datestring1 + "')" + or_and;

                }
            }
            else
            {
                if (((temp1.Text != "  .  .") && (temp1.Text.Length == 10)))
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(temp1.Text);
                        string datestring = dt.ToString("yyyy-MM-dd");
                        filter_text = filter_text + dataGridView2.Columns[8].DataPropertyName + " ='" + datestring + " 00:00:00'" + or_and;
                    }
                    catch
                    {

                    }
                }

                if (((temp2.Text != "  .  .") && (temp2.Text.Length == 10)))
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(temp2.Text);
                        string datestring = dt.ToString("yyyy-MM-dd");
                        filter_text = filter_text + dataGridView2.Columns[8].DataPropertyName + " ='" + datestring + " 00:00:00'" + or_and;
                    }
                    catch
                    {

                    }
                }
            }

            if (filter_text.Length > 0)
            {
                if (filter_text.Contains(" or ") || filter_text.Contains(" and "))
                {
                    filter_text = filter_text.Substring(0, filter_text.Length - 4);
                }

                list = await getpage_filter(filter_text);
                dataGridView1.DataSource = list.ToList();
            }
            else
            {
                list = await getpage_filter_all();
                dataGridView1.DataSource = list.ToList();
            }

            

            //dataGridView1.Refresh();
            //.DefaultView.RowFilter = string.Format("Field = '{0}'", textBoxFilter.Text);
            return;
            if (!string.IsNullOrWhiteSpace(filter_text))
            {
                filter_text = filter_text.Substring(0, filter_text.Length - 5);
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filter_text;
            }
            else
            {
                (dataGridView1.DataSource as BindingSource).Filter = "";
            }


            dataGridView1.Refresh();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (row_added)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1[1, e.RowIndex];
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            { or_and = " or  "; }
            else
            { or_and = " and "; }
        }

        private void _txtbox_TextChanged(object sender, EventArgs e)
        {
            FFilter_grid();
        }

        private void _temp_che_CheckstateChanged(object sender, EventArgs e)
        {
            FFilter_grid();
        }

        private void _txtbox_TextChanged_corp(object sender, EventArgs e)
        {
            FFilter_grid_corp();
        }

        private void _temp_che_CheckstateChanged_corp(object sender, EventArgs e)
        {
            FFilter_grid_corp();
        }

        private void _temp_che_CheckstateChanged_one_pass(object sender, EventArgs e)
        {
            FFilter_grid_one_pass();
        }

        private void _txtbox_TextChanged_one_pass(object sender, EventArgs e)
        {
            FFilter_grid_one_pass();
        }


        public void filter_boxses()
        {

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (i == 0 )
                {

                }
                else
                {
                    //maskedTextBox1.Mask = "00.00.0000"; dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;

                    if (i == 8)
                    {
                        MaskedTextBox temp_che = new MaskedTextBox();
                        //temp_che.CustomFormat = "dd.mm.yyyy";
                        //temp_che.Format = DateTimePickerFormat.Custom;
                        temp_che.Name = "maskedTextBox1";
                        temp_che.Mask = "00.00.0000";
                        temp_che.Tag = i;
                        Rectangle dd = dataGridView1.GetCellDisplayRectangle(i, -1, true);
                        //temp_che.Width = dd.Width - 8;
                        temp_che.Width = (dd.Width/2) - 8;
                        temp_che.BackColor = SystemColors.Window;
                        temp_che.AutoSize = false;
                        temp_che.Height = 20;
                        //temp_che.Location = new Point(dd.X + 3, dd.Y + 20);
                        temp_che.Anchor = AnchorStyles.None;
                        //temp_che.Location = new Point((dd.X + (dd.Width / 2)) - 7, dd.Y + 22);
                        temp_che.Location = new Point(dd.X + 3, dd.Y + 48);
                        //temp_che.Location = new Point(9, 9);
                        temp_che.Visible = true;
                        temp_che.Enabled = true;
                        temp_che.ForeColor = Color.Navy;
                        temp_che.Height = 29;
                        temp_che.TextChanged   += new System.EventHandler(_temp_che_CheckstateChanged);
                        dataGridView1.Controls.Add(temp_che);


                        temp_che = new MaskedTextBox();
                        temp_che.Name = "maskedTextBox2";
                        temp_che.Mask = "00.00.0000";
                        temp_che.Tag = i;
                        dd = dataGridView1.GetCellDisplayRectangle(i, -1, true);
                        temp_che.Width = (dd.Width/2) - 8;
                        temp_che.BackColor = SystemColors.Window;
                        temp_che.AutoSize = false;
                        temp_che.Height = 20;
                        //temp_che.Location = new Point(dd.X + 3, dd.Y + 20);
                        temp_che.Anchor = AnchorStyles.None;
                        //temp_che.Location = new Point((dd.X + (dd.Width / 2)) - 7, dd.Y + 22);
                        temp_che.Location = new Point((dd.X + temp_che.Width+9) + 3, dd.Y + 48);
                        //temp_che.Location = new Point(9, 9);
                        temp_che.Visible = true;
                        temp_che.Enabled = true;
                        temp_che.ForeColor = Color.Navy;
                        temp_che.Height = 29;
                        temp_che.TextChanged += new System.EventHandler(_temp_che_CheckstateChanged);
                        dataGridView1.Controls.Add(temp_che);



                    }
                    else
                    {

                        TextBox txtbox = new TextBox();
                        txtbox.Name = "TxtBoxVol_" + i.ToString();
                        txtbox.Tag = i;
                        //txtbox.Text = i.ToString();
                        //panel1.Controls.Add(txtbox);

                        Rectangle dd = dataGridView1.GetCellDisplayRectangle(i, -1, true);
                        txtbox.Width = dd.Width - 8;


                        //this.ClientSize.Height / 2 - _thePanel.Size.Height / 2);

                        txtbox.Location = new Point(dd.X + 3, dd.Y + 48);

                        //txtbox.Location = new Point((dd.Width - 4) / 2 - txtbox.Width / 2);
                        txtbox.Visible = true;
                        txtbox.Enabled = true;
                        txtbox.ForeColor = Color.Navy;
                        txtbox.TextChanged += new System.EventHandler(_txtbox_TextChanged);
                        dataGridView1.Controls.Add(txtbox);

                                                
                    }
                }

            }

            //dataGridView3.ColumnWidthChanged += dataGridView3_ColumnWidthChanged;
        }


        public void filter_boxses_one_pass()
        {

            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                if (i == 0)
                {

                }
                else
                {
                    //maskedTextBox1.Mask = "00.00.0000"; dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;

                    if (i == 7)
                    {
                        MaskedTextBox temp_che_222 = new MaskedTextBox();
                        //temp_che.CustomFormat = "dd.mm.yyyy";
                        //temp_che.Format = DateTimePickerFormat.Custom;
                        temp_che_222.Name = "maskedTextBox_one_pass_time_1";
                        temp_che_222.Mask = "00:00";
                        temp_che_222.Tag = i;
                        Rectangle dd = dataGridView2.GetCellDisplayRectangle(i, -1, true);
                        temp_che_222.Width = (dd.Width / 2) - 8;
                        temp_che_222.BackColor = SystemColors.Window;
                        temp_che_222.AutoSize = false;
                        temp_che_222.Height = 20;
                        //temp_che.Location = new Point(dd.X + 3, dd.Y + 20);
                        temp_che_222.Anchor = AnchorStyles.None;
                        //temp_che.Location = new Point((dd.X + (dd.Width / 2)) - 7, dd.Y + 22);
                        temp_che_222.Location = new Point(dd.X + 3, dd.Y + 48);
                        //temp_che.Location = new Point(9, 9);
                        temp_che_222.Visible = true;
                        temp_che_222.Enabled = true;
                        temp_che_222.ForeColor = Color.Navy;
                        temp_che_222.Height = 29;
                        temp_che_222.TextChanged += new System.EventHandler(_temp_che_CheckstateChanged_one_pass);
                        dataGridView2.Controls.Add(temp_che_222);

                    }
                        if (i == 8)
                    {
                        MaskedTextBox temp_che = new MaskedTextBox();
                        //temp_che.CustomFormat = "dd.mm.yyyy";
                        //temp_che.Format = DateTimePickerFormat.Custom;
                        temp_che.Name = "maskedTextBox_one_pass_1";
                        temp_che.Mask = "00.00.0000";
                        temp_che.Tag = i;
                        Rectangle dd = dataGridView2.GetCellDisplayRectangle(i, -1, true);
                        temp_che.Width = (dd.Width / 2) - 8;
                        temp_che.BackColor = SystemColors.Window;
                        temp_che.AutoSize = false;
                        temp_che.Height = 20;
                        //temp_che.Location = new Point(dd.X + 3, dd.Y + 20);
                        temp_che.Anchor = AnchorStyles.None;
                        //temp_che.Location = new Point((dd.X + (dd.Width / 2)) - 7, dd.Y + 22);
                        temp_che.Location = new Point(dd.X + 3, dd.Y + 48);
                        //temp_che.Location = new Point(9, 9);
                        temp_che.Visible = true;
                        temp_che.Enabled = true;
                        temp_che.ForeColor = Color.Navy;
                        temp_che.Height = 29;
                        temp_che.TextChanged += new System.EventHandler(_temp_che_CheckstateChanged_one_pass);
                        dataGridView2.Controls.Add(temp_che);

                        var temp_che_2 = new MaskedTextBox();
                        temp_che_2.Name = "maskedTextBox_one_pass_2";
                        temp_che_2.Mask = "00.00.0000";
                        temp_che_2.Tag = i;
                        dd = dataGridView2.GetCellDisplayRectangle(i, -1, true);
                        temp_che_2.Width = (dd.Width / 2) - 8;
                        temp_che_2.BackColor = SystemColors.Window;
                        temp_che_2.AutoSize = false;
                        temp_che_2.Height = 20;
                        //temp_che.Location = new Point(dd.X + 3, dd.Y + 20);
                        temp_che_2.Anchor = AnchorStyles.None;
                        //temp_che.Location = new Point((dd.X + (dd.Width / 2)) - 7, dd.Y + 22);
                        temp_che_2.Location = new Point((dd.X + temp_che.Width + 9) + 3, dd.Y + 48);
                        //temp_che.Location = new Point(9, 9);
                        temp_che_2.Visible = true;
                        temp_che_2.Enabled = true;
                        temp_che_2.ForeColor = Color.Navy;
                        temp_che_2.Height = 29;
                        temp_che_2.TextChanged += new System.EventHandler(_temp_che_CheckstateChanged_one_pass);
                        dataGridView2.Controls.Add(temp_che_2);

                    }
                    else
                    {

                        TextBox txtbox = new TextBox();
                        txtbox.Name = "TxtBoxVol_one_pass" + i.ToString();
                        txtbox.Tag = i;
                        //txtbox.Text = i.ToString();
                        //panel1.Controls.Add(txtbox);

                        Rectangle dd = dataGridView2.GetCellDisplayRectangle(i, -1, true);
                        txtbox.Width = dd.Width - 8;


                        //this.ClientSize.Height / 2 - _thePanel.Size.Height / 2);

                        txtbox.Location = new Point(dd.X + 3, dd.Y + 48);

                        //txtbox.Location = new Point((dd.Width - 4) / 2 - txtbox.Width / 2);
                        txtbox.Visible = true;
                        txtbox.Enabled = true;
                        txtbox.ForeColor = Color.Navy;
                        txtbox.TextChanged += new System.EventHandler(_txtbox_TextChanged_one_pass);
                        dataGridView2.Controls.Add(txtbox);



                        //dataGridView3.Columns[i].HeaderCell.po

                        //Point absolutePosition = this.dataGridView3.Columns[i].HeaderCell.PointToScreen(this.radGridView.CurrentCell.Location);

                        //dataGridView3.Columns[i].HeaderCell.Size
                        //dataGridView3.Controls.Add(textBox5);
                        //textBox5.Location = new Point(5, 5);
                    }
                }

            }

            //dataGridView3.ColumnWidthChanged += dataGridView3_ColumnWidthChanged;
        }

        public void filter_boxses_corp()
        {

            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                if (i == 0)
                {

                }
                else
                {
                    //maskedTextBox1.Mask = "00.00.0000"; dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;

                    if (i == 8)
                    {
                        MaskedTextBox temp_che = new MaskedTextBox();
                        //temp_che.CustomFormat = "dd.mm.yyyy";
                        //temp_che.Format = DateTimePickerFormat.Custom;
                        temp_che.Name = "maskedTextBox_corp_1";
                        temp_che.Mask = "00.00.0000";
                        temp_che.Tag = i;
                        Rectangle dd = dataGridView3.GetCellDisplayRectangle(i, -1, true);
                        temp_che.Width = (dd.Width/2) - 8;
                        temp_che.BackColor = SystemColors.Window;
                        temp_che.AutoSize = false;
                        temp_che.Height = 20;
                        //temp_che.Location = new Point(dd.X + 3, dd.Y + 20);
                        temp_che.Anchor = AnchorStyles.None;
                        //temp_che.Location = new Point((dd.X + (dd.Width / 2)) - 7, dd.Y + 22);
                        temp_che.Location = new Point(dd.X + 3, dd.Y + 48);
                        //temp_che.Location = new Point(9, 9);
                        temp_che.Visible = true;
                        temp_che.Enabled = true;
                        temp_che.ForeColor = Color.Navy;
                        temp_che.Height = 29;
                        temp_che.TextChanged += new System.EventHandler(_temp_che_CheckstateChanged_corp);
                        dataGridView3.Controls.Add(temp_che);

                        var temp_che_2 = new MaskedTextBox();
                        temp_che_2.Name = "maskedTextBox_corp_2";
                        temp_che_2.Mask = "00.00.0000";
                        temp_che_2.Tag = i;
                        dd = dataGridView1.GetCellDisplayRectangle(i, -1, true);
                        temp_che_2.Width = (dd.Width / 2) - 8;
                        temp_che_2.BackColor = SystemColors.Window;
                        temp_che_2.AutoSize = false;
                        temp_che_2.Height = 20;
                        //temp_che.Location = new Point(dd.X + 3, dd.Y + 20);
                        temp_che_2.Anchor = AnchorStyles.None;
                        //temp_che.Location = new Point((dd.X + (dd.Width / 2)) - 7, dd.Y + 22);
                        temp_che_2.Location = new Point((dd.X + temp_che.Width + 9) + 3, dd.Y + 48);
                        //temp_che.Location = new Point(9, 9);
                        temp_che_2.Visible = true;
                        temp_che_2.Enabled = true;
                        temp_che_2.ForeColor = Color.Navy;
                        temp_che_2.Height = 29;
                        temp_che_2.TextChanged += new System.EventHandler(_temp_che_CheckstateChanged_corp);
                        dataGridView3.Controls.Add(temp_che_2);

                    }
                    else
                    {

                        TextBox txtbox = new TextBox();
                        txtbox.Name = "TxtBoxVol_corp" + i.ToString();
                        txtbox.Tag = i;
                        //txtbox.Text = i.ToString();
                        //panel1.Controls.Add(txtbox);

                        Rectangle dd = dataGridView3.GetCellDisplayRectangle(i, -1, true);
                        txtbox.Width = dd.Width - 8;


                        //this.ClientSize.Height / 2 - _thePanel.Size.Height / 2);

                        txtbox.Location = new Point(dd.X + 3, dd.Y + 48);

                        //txtbox.Location = new Point((dd.Width - 4) / 2 - txtbox.Width / 2);
                        txtbox.Visible = true;
                        txtbox.Enabled = true;
                        txtbox.ForeColor = Color.Navy;
                        txtbox.TextChanged += new System.EventHandler(_txtbox_TextChanged_corp);
                        dataGridView3.Controls.Add(txtbox);



                        //dataGridView3.Columns[i].HeaderCell.po

                        //Point absolutePosition = this.dataGridView3.Columns[i].HeaderCell.PointToScreen(this.radGridView.CurrentCell.Location);

                        //dataGridView3.Columns[i].HeaderCell.Size
                        //dataGridView3.Controls.Add(textBox5);
                        //textBox5.Location = new Point(5, 5);
                    }
                }

            }

            //dataGridView3.ColumnWidthChanged += dataGridView3_ColumnWidthChanged;
        }



        private async void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                variables.add_edit_ = true;
                add_edit fo = new add_edit();
                fo.Text = "GM დამატება / რედაქტირება";
                fo.ShowDialog();
                if (variables.yyes)
                {

                    string datestring = variables.dateTimePicker_.ToString("yyyy-MM-dd") + " 00:00:00"; ;

                    dataTable2TableAdapter.InsertQuery_main(
                    variables.textBox1_Text,
                    variables.textBox2_Text,
                    variables.textBox3_Text,
                    variables.textBox4_Text,
                    variables.textBox5_Text,
                    variables.textBox6_Text,
                    variables.textBox7_Text,
                    DateTime.ParseExact(datestring, "yyyy-MM-dd 00:00:00", CultureInfo.InvariantCulture),
                    variables.numericUpDown1_);



                    list = await getpage_update_grid();
                    dataGridView1.DataSource = list.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", list.PageCount, list.PageCount);
                    button2.Enabled = false;
                    if (list.PageCount > 1) { button1.Enabled = true; }

                    int nRowIndex = dataGridView1.Rows.Count - 1;
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[nRowIndex].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1[1, nRowIndex];
                }
            }
            if (tabControl1.SelectedIndex == 1)
            {
                variables.add_edit_ = true;
                add_edit fo = new add_edit();
                fo.Text = "CORP დამატება / რედაქტირება";
                fo.ShowDialog();
                if (variables.yyes)
                {

                    string datestring = variables.dateTimePicker_.ToString("yyyy-MM-dd") + " 00:00:00"; ;

                    dataTable3TableAdapter.InsertQuery_main_corp(
                    variables.textBox1_Text,
                    variables.textBox2_Text,
                    variables.textBox3_Text,
                    variables.textBox4_Text,
                    variables.textBox5_Text,
                    variables.textBox6_Text,
                    variables.textBox7_Text,
                    DateTime.ParseExact(datestring, "yyyy-MM-dd 00:00:00", CultureInfo.InvariantCulture),
                    variables.numericUpDown1_);



                    list1 = await getpage_update_grid_corp();
                    dataGridView3.DataSource = list1.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", list1.PageCount, list1.PageCount);
                    button2.Enabled = false;
                    if (list1.PageCount > 1) { button1.Enabled = true; }

                    int nRowIndex = dataGridView3.Rows.Count - 1;
                    dataGridView3.ClearSelection();
                    dataGridView3.Rows[nRowIndex].Selected = true;
                    dataGridView3.CurrentCell = dataGridView3[1, nRowIndex];
                }
            }

            if (tabControl1.SelectedIndex == 2)
            {
                variables.add_edit_ = true;
                add_edit_one_pass fo = new add_edit_one_pass();
                fo.Text = "ერთჯერადი საშვი დამატება / რედაქტირება";
                fo.ShowDialog();
                if (variables.yyes)
                {
                    string datestring = variables.dateTimePicker_.ToString("yyyy-MM-dd")+" 00:00:00";

                    dataTable1TableAdapter.InsertQuery_one_pass(
                    variables.textBox1_Text,
                    variables.textBox2_Text,
                    variables.textBox3_Text,
                    variables.textBox4_Text,
                    variables.textBox5_Text,
                    variables.textBox6_Text,
                    variables.ttime,
                    DateTime.ParseExact(datestring, "yyyy-MM-dd 00:00:00", CultureInfo.InvariantCulture));


                    list2 = await getpage_update_grid_one_pass();
                    dataGridView2.DataSource = list2.ToList();
                    label2.Text = string.Format("გვერდი {0}/{1} დან", list2.PageCount, list2.PageCount);
                    button2.Enabled = false;
                    if (list2.PageCount > 1) { button1.Enabled = true; }

                    int nRowIndex = dataGridView2.Rows.Count - 1;
                    dataGridView2.ClearSelection();
                    dataGridView2.Rows[nRowIndex].Selected = true;
                    dataGridView2.CurrentCell = dataGridView2[1, nRowIndex];
                }
            }


            try
            {
                label3.Text = "ჯამი: " + dataTable2TableAdapter.ScalarQuery_sum_main().ToString();
                label4.Text = "ჯამი: " + dataTable3TableAdapter.ScalarQuery_sum_main_corp().ToString();
            }
            catch
            {
                label3.Text = "ჯამი: 0";
                label4.Text = "ჯამი: 0";
            }

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                variables.textBox1_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
                variables.textBox2_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
                variables.textBox3_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[3].Value.ToString();
                variables.textBox4_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[4].Value.ToString();
                variables.textBox5_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[5].Value.ToString();
                variables.textBox6_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[6].Value.ToString();
                variables.textBox7_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[7].Value.ToString();
                variables.dateTimePicker_ = Convert.ToDateTime(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[8].Value.ToString());
                variables.numericUpDown1_ = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[9].Value.ToString());

                variables.add_edit_ = false;
                add_edit fo = new add_edit();
                fo.Text = "GM დამატება / რედაქტირება";
                fo.ShowDialog();
                if (variables.yyes)
                {
                    Int32 ro_in = dataGridView1.SelectedRows[0].Index;

                    string datestring = variables.dateTimePicker_.ToString("yyyy-MM-dd") + " 00:00:00"; ;

                    dataTable2TableAdapter.UpdateQuery(
                    variables.textBox1_Text,
                    variables.textBox2_Text,
                    variables.textBox3_Text,
                    variables.textBox4_Text,
                    variables.textBox5_Text,
                    variables.textBox6_Text,
                    variables.textBox7_Text,
                    DateTime.ParseExact(datestring, "yyyy-MM-dd 00:00:00", CultureInfo.InvariantCulture),
                    variables.numericUpDown1_,
                    Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value)
                    );

                    list = await getpage(pagenumber);
                    dataGridView1.DataSource = list.ToList();
                    label1.TextAlign = ContentAlignment.MiddleCenter;
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber, list.PageCount);

                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[ro_in].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1[1, ro_in];
                }

            }
            if (tabControl1.SelectedIndex == 1)
            {
                variables.textBox1_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[1].Value.ToString();
                variables.textBox2_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[2].Value.ToString();
                variables.textBox3_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[3].Value.ToString();
                variables.textBox4_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[4].Value.ToString();
                variables.textBox5_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[5].Value.ToString();
                variables.textBox6_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[6].Value.ToString();
                variables.textBox7_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[7].Value.ToString();
                variables.dateTimePicker_ = Convert.ToDateTime(dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[8].Value.ToString());
                variables.numericUpDown1_ = Convert.ToDecimal(dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[9].Value.ToString());

                variables.add_edit_ = false;
                add_edit fo = new add_edit();
                fo.Text = "CORP დამატება / რედაქტირება";
                fo.ShowDialog();
                if (variables.yyes)
                {
                    Int32 ro_in = dataGridView3.SelectedRows[0].Index;

                    string datestring = variables.dateTimePicker_.ToString("yyyy-MM-dd") + " 00:00:00"; ;

                    dataTable3TableAdapter.UpdateQuery_main_corp(
                    variables.textBox1_Text,
                    variables.textBox2_Text,
                    variables.textBox3_Text,
                    variables.textBox4_Text,
                    variables.textBox5_Text,
                    variables.textBox6_Text,
                    variables.textBox7_Text,
                    DateTime.ParseExact(datestring, "yyyy-MM-dd 00:00:00", CultureInfo.InvariantCulture),
                    variables.numericUpDown1_,
                    Convert.ToInt32(dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[0].Value)
                    );

                    list1 = await getpage_corp(pagenumber_2);
                    dataGridView3.DataSource = list1.ToList();
                    label1.TextAlign = ContentAlignment.MiddleCenter;
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_2, list1.PageCount);

                    dataGridView3.ClearSelection();
                    dataGridView3.Rows[ro_in].Selected = true;
                    dataGridView3.CurrentCell = dataGridView3[1, ro_in];
                }
            }


            if (tabControl1.SelectedIndex == 2)
            {

                variables.textBox1_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[1].Value.ToString();
                variables.textBox2_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[2].Value.ToString();
                variables.textBox3_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[3].Value.ToString();
                variables.textBox4_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[4].Value.ToString();
                variables.textBox5_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[5].Value.ToString();
                variables.textBox6_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[6].Value.ToString();
                variables.dateTimePicker_ = Convert.ToDateTime(dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[8].Value.ToString());
                variables.ttime = Convert.ToDateTime(dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[7].Value.ToString());

                variables.add_edit_ = false;
                add_edit_one_pass fo = new add_edit_one_pass();
                fo.Text = "ერთჯერადი საშვი დამატება / რედაქტირება";
                fo.ShowDialog();
                if (variables.yyes)
                {
                    Int32 ro_in = dataGridView2.SelectedRows[0].Index;

                    string datestring = variables.dateTimePicker_.ToString("yyyy-MM-dd") + " 00:00:00"; ;

                    dataTable1TableAdapter.UpdateQuery(
                    variables.textBox1_Text,
                    variables.textBox2_Text,
                    variables.textBox3_Text,
                    variables.textBox4_Text,
                    variables.textBox5_Text,
                    variables.textBox6_Text,
                    variables.ttime,
                    DateTime.ParseExact(datestring, "yyyy-MM-dd 00:00:00", CultureInfo.InvariantCulture),
                    Convert.ToInt32(dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[0].Value)
                    );

                    list2 = await getpage_one_pass(pagenumber_3);
                    dataGridView2.DataSource = list2.ToList();
                    label2.TextAlign = ContentAlignment.MiddleCenter;
                    label2.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_3, list1.PageCount);

                    dataGridView2.ClearSelection();
                    dataGridView2.Rows[ro_in].Selected = true;
                    dataGridView2.CurrentCell = dataGridView2[1, ro_in];
                }
            }


            try
            {
                label3.Text = "ჯამი: " + dataTable2TableAdapter.ScalarQuery_sum_main().ToString();
                label4.Text = "ჯამი: " + dataTable3TableAdapter.ScalarQuery_sum_main_corp().ToString();
            }
            catch
            {
                label3.Text = "ჯამი: 0";
                label4.Text = "ჯამი: 0";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                report rep = new report();
                variables.textBox1_Text = "GM საშვი N: "+dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
                variables.textBox2_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
                variables.textBox3_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[3].Value.ToString();
                variables.textBox4_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[4].Value.ToString();
                variables.textBox5_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[5].Value.ToString();
                variables.textBox6_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[6].Value.ToString();
                variables.textBox7_Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[7].Value.ToString();
                variables.dateTimePicker_ = Convert.ToDateTime(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[8].Value.ToString());
                variables.numericUpDown1_ = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[9].Value.ToString());
                rep.ShowDialog();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                report rep = new report();
                variables.textBox1_Text = "CORP საშვი N: "+dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[1].Value.ToString();
                variables.textBox2_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[2].Value.ToString();
                variables.textBox3_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[3].Value.ToString();
                variables.textBox4_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[4].Value.ToString();
                variables.textBox5_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[5].Value.ToString();
                variables.textBox6_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[6].Value.ToString();
                variables.textBox7_Text = dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[7].Value.ToString();
                variables.dateTimePicker_ = Convert.ToDateTime(dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[8].Value.ToString());
                variables.numericUpDown1_ = Convert.ToDecimal(dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[9].Value.ToString());
                rep.ShowDialog();
            }

            if (tabControl1.SelectedIndex == 2)
            {
                report_form_one_pass rep = new report_form_one_pass();
                variables.textBox1_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[1].Value.ToString();
                variables.textBox2_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[2].Value.ToString();
                variables.textBox3_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[3].Value.ToString();
                variables.textBox4_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[4].Value.ToString();
                variables.textBox5_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[5].Value.ToString();
                variables.textBox6_Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[6].Value.ToString();
                variables.dateTimePicker_ = Convert.ToDateTime(dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[8].Value.ToString());
                variables.ttime = Convert.ToDateTime(dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[7].Value.ToString());
                rep.ShowDialog();
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //TabPage page = tabControl1.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, tabControl1.TabPages[e.Index].Text, e.Font, paddedBounds, e.ForeColor);
        }

        private void dataGridView3_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (row_added)
            {
                dataGridView3.ClearSelection();
                dataGridView3.Rows[e.RowIndex].Selected = true;
                dataGridView3.CurrentCell = dataGridView3[1, e.RowIndex];
            }
        }

        private void dataGridView3_MouseUp(object sender, MouseEventArgs e)
        {

            DataGridView.HitTestInfo myHitTestUp = dataGridView3.HitTest(e.X, e.Y);
            if (myHitTestUp.Type == DataGridViewHitTestType.ColumnHeader)
            {
                
                foreach (Control item in dataGridView3.Controls.OfType<TextBox>())
                {
                    item.Visible = false;
                    //item.Enabled = false;
                    //dataGridView3.Controls[item.inde].Visible = false;
                }
                

                Application.DoEvents();
                relocate_filter_text_box_corp();
                Application.DoEvents();

                foreach (Control item in dataGridView3.Controls.OfType<TextBox>())
                {
                    item.Visible = true;
                    //item.Enabled = true;
                    //dataGridView3.Controls[item.inde].Visible = false;
                }

                //for (int i = 0; i < dataGridView3.Controls.Count; i++)
                //{
                //    dataGridView3.Controls[i].Visible = true;
                //}
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (list.HasNextPage) { button2.Enabled = true; } else { button2.Enabled = false; }
                if (list.HasPreviousPage) { button1.Enabled = true; } else { button1.Enabled = false; }
                label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber, list.PageCount);
                relocate_filter_text_box();
                if (list.PageCount == 0)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button4.Enabled = false;
                    button7.Enabled = false;
                }
                else
                {
                    if (list.HasNextPage)
                    {
                        button2.Enabled = true;
                        button4.Enabled = true;
                    }

                    if (list.HasPreviousPage)
                    {
                        button1.Enabled = true;
                        button7.Enabled = true;
                    }
                }
            }
            if (tabControl1.SelectedIndex == 1)
            {
                if (list1.HasNextPage) { button2.Enabled = true; } else { button2.Enabled = false; }
                if (list1.HasPreviousPage) { button1.Enabled = true; } else { button1.Enabled = false; }
                label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_2, list1.PageCount);
                relocate_filter_text_box_corp();
                if (list1.PageCount == 0)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button4.Enabled = false;
                    button7.Enabled = false;
                }
                else
                {
                    if (list1.HasNextPage)
                    {
                        button2.Enabled = true;
                        button4.Enabled = true;
                    }

                    if (list1.HasPreviousPage)
                    {
                        button1.Enabled = true;
                        button7.Enabled = true;
                    }
                }
            }
            if (tabControl1.SelectedIndex == 2)
            {
                if (list2.HasNextPage) { button2.Enabled = true; } else { button2.Enabled = false; }
                if (list2.HasPreviousPage) { button1.Enabled = true; } else { button1.Enabled = false; }
                label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_3, list2.PageCount);
                relocate_filter_text_box_one_pass();
                if (list2.PageCount == 0)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button4.Enabled = false;
                    button7.Enabled = false;
                }
                else
                {
                    if (list2.HasNextPage)
                    {
                        button2.Enabled = true;
                        button4.Enabled = true;
                    }

                    if (list2.HasPreviousPage)
                    {
                        button1.Enabled = true;
                        button7.Enabled = true;
                    }
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {

                
                relocate_filter_text_box();
            }
            if (tabControl1.SelectedIndex == 1)
            {
               
                relocate_filter_text_box_corp();
            }
            if (tabControl1.SelectedIndex == 2)
            {

                relocate_filter_text_box_one_pass();
            }
        }

        private void dataGridView2_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo myHitTestUp = dataGridView2.HitTest(e.X, e.Y);
            if (myHitTestUp.Type == DataGridViewHitTestType.ColumnHeader)
            {

                foreach (Control item in dataGridView2.Controls.OfType<TextBox>())
                {
                    item.Visible = false;
                    //item.Enabled = false;
                    //dataGridView3.Controls[item.inde].Visible = false;
                }


                Application.DoEvents();
                relocate_filter_text_box_one_pass();
                Application.DoEvents();

                foreach (Control item in dataGridView2.Controls.OfType<TextBox>())
                {
                    item.Visible = true;
                    //item.Enabled = true;
                    //dataGridView3.Controls[item.inde].Visible = false;
                }

                //for (int i = 0; i < dataGridView3.Controls.Count; i++)
                //{
                //    dataGridView3.Controls[i].Visible = true;
                //}
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                
                    pagenumber = list.PageCount;
                    list = await getpage(pagenumber);
                    dataGridView1.DataSource = list.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber, list.PageCount);
                    button4.Enabled = false;
                    button2.Enabled = false;
                button7.Enabled = true;
                button1.Enabled = true;


                relocate_filter_text_box();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                
                    pagenumber_2 = list1.PageCount;
                    list1 = await getpage_corp(pagenumber_2);
                    dataGridView3.DataSource = list1.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_2, list1.PageCount);
                button4.Enabled = false;
                button2.Enabled = false;
                button7.Enabled = true;
                button1.Enabled = true;


                relocate_filter_text_box_corp();
            }

            if (tabControl1.SelectedIndex == 2)
            {
                
                    pagenumber_3 = list2.PageCount;
                    list2 = await getpage_one_pass(pagenumber_3);
                    dataGridView2.DataSource = list1.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_3, list1.PageCount);
                button4.Enabled = false;
                button2.Enabled = false;
                button7.Enabled = true;
                button1.Enabled = true;

                relocate_filter_text_box_one_pass();
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                
                    pagenumber = 1;
                    list = await getpage(pagenumber);
                    dataGridView1.DataSource = list.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber, list.PageCount);
                button4.Enabled = true;
                button2.Enabled = true;
                button7.Enabled = false;
                button1.Enabled = false;

                relocate_filter_text_box();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                
                    pagenumber_2 =1;
                    list1 = await getpage_corp(pagenumber_2);
                    dataGridView3.DataSource = list1.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_2, list1.PageCount);
                button4.Enabled = true;
                button2.Enabled = true;
                button7.Enabled = false;
                button1.Enabled = false;


                relocate_filter_text_box_corp();
            }

            if (tabControl1.SelectedIndex == 2)
            {
                
                    pagenumber_3 = 1;
                    list2 = await getpage_one_pass(pagenumber_3);
                    dataGridView2.DataSource = list1.ToList();
                    label1.Text = string.Format("გვერდი {0}/{1} დან", pagenumber_3, list1.PageCount);
                button4.Enabled = true;
                button2.Enabled = true;
                button7.Enabled = false;
                button1.Enabled = false;

                relocate_filter_text_box_one_pass();
            }
        }
    }
}
