using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_p2
{
    public partial class Form1 : Form
    {
        public DataClasses2DataContext db;

        public Form1()
        {
            InitializeComponent();
            db = new DataClasses2DataContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.posts;
            dataGridView2.DataSource = db.comments;
            dataGridView3.DataSource = db.users;

            toolStripAddItemButton.Enabled = true;
            toolStripDeleteItemButton.Enabled = true;
            saveToolStripButton.Enabled = true;
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void postId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigator2_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click_1(object sender, EventArgs e)
        {
            string idText = postId.Text;
            int id = Int32.Parse(idText);

            int userId = 0;
            string userIdText = postUserID.Text;
            if (userIdText.Length > 0)
            {
                userId = Int32.Parse(userIdText);
            }

            posts postForUpdate = db.posts.Where(it => it.id == id).Single();

            if (postHeader.Text.Length > 0)
            {
                postForUpdate.header = postHeader.Text;
            }
            if (postShortTopic.Text.Length > 0)
            {
                postForUpdate.short_topic = postShortTopic.Text;
            }
            if (postMainTopic.Text.Length > 0)
            {
                postForUpdate.main_topic = postMainTopic.Text;
            }
            if (postForUpdate.user_id != userId && userId > 0)
            {
                postForUpdate.user_id = userId;
            }

            db.SubmitChanges();

            updatePostTableView();
        }

        private void clearInput()
        {
            postId.Text = "";
            postShortTopic.Text = "";
            postHeader.Text = "";
            postMainTopic.Text = "";
            postUserID.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDeleteItemButton_Click(object sender, EventArgs e)
        {
            string idText = deleteIdTextBox.Text;
            int id = Int32.Parse(idText);

            posts postForDelete = db.posts.Where(it => it.id == id).Single();
            db.posts.DeleteOnSubmit(postForDelete);
            db.SubmitChanges();

            updatePostTableView();

            deleteIdTextBox.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripAddItemButton_Click(object sender, EventArgs e)
        {
            string idText = postId.Text;
            int id = Int32.Parse(idText);

            string userIDT = postUserID.Text;
            int userID = Int32.Parse(userIDT);

            posts newPost = new posts();
            newPost.id = id;
            newPost.header = postHeader.Text;
            newPost.short_topic = postShortTopic.Text;
            newPost.main_topic = postMainTopic.Text;
            newPost.user_id = userID;

            db.posts.InsertOnSubmit(newPost);
            db.SubmitChanges();

            updatePostTableView();

            clearInput();
        }

        private void updatePostTableView()
        {
            db = new DataClasses2DataContext();
            dataGridView1.DataSource = db.posts;
            //dataGridView2.DataSource = db.comments;
            //dataGridView3.DataSource = db.users;

            dataGridView1.Refresh();
            //dataGridView2.Refresh();
            //dataGridView3.Refresh();
        }

        private void updateCommentsTableView()
        {
            db = new DataClasses2DataContext();
            //dataGridView1.DataSource = db.posts;
            dataGridView2.DataSource = db.comments;
            //dataGridView3.DataSource = db.users;

            //dataGridView1.Refresh();
            dataGridView2.Refresh();
            //dataGridView3.Refresh();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void filterByAge_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.posts.OrderBy(it => it.header).Select(it => it);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatePostTableView();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            dataGridView2.DataSource = from o in db.comments
                                       where o.parent_id.Equals(null)
                                       select o;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateCommentsTableView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = from u in db.users
                                       where u.comments.Count() > 0 && u.comments.Any(it => it.parent_id.Equals(null))
                                       orderby u.comments.Count, u.login
                                       select new
                                       {
                                           u.id,
                                           u.login,
                                           u.password,
                                           u.avatar,
                                           u.karma,
                                           u.comments,
                                       };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = from u in db.posts.Where(it => it.comments.Count > 0).Select(it => it.users)
                                       group u by u.login into u
                                       select new
                                       {
                                           login = u.Key,
                                           count = u.Count(),
                                       };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            db = new DataClasses2DataContext();
            //dataGridView1.DataSource = db.posts;
            //dataGridView2.DataSource = db.comments;
            dataGridView3.DataSource = db.users;

            //dataGridView1.Refresh();
            //dataGridView2.Refresh();
            dataGridView3.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = from u in db.users.Where(it => it.posts.Count == 0)
                                       select new
                                       {
                                           u.id,
                                           u.login,
                                           u.password,
                                           u.avatar,
                                           u.karma,
                                           u.comments,
                                       };
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = from u in db.posts.Where(it => it.comments.Count > 0).Select(it => it.users).Distinct()
                                       select new
                                       {
                                           u.id,
                                           u.login,
                                           u.password,
                                           u.avatar,
                                           u.karma,
                                           u.comments,
                                       };
        }
    }
}
