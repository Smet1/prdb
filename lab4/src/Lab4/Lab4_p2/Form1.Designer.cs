namespace Lab4_p2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripAddItemButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDeleteItemButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.postId = new System.Windows.Forms.TextBox();
            this.postHeader = new System.Windows.Forms.TextBox();
            this.postShortTopic = new System.Windows.Forms.TextBox();
            this.postMainTopic = new System.Windows.Forms.TextBox();
            this.postUserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filterByAge = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.showAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(660, 179);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddItemButton,
            this.toolStripDeleteItemButton,
            this.saveToolStripButton});
            this.bindingNavigator1.Location = new System.Drawing.Point(130, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(81, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // toolStripAddItemButton
            // 
            this.toolStripAddItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAddItemButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAddItemButton.Image")));
            this.toolStripAddItemButton.Name = "toolStripAddItemButton";
            this.toolStripAddItemButton.RightToLeftAutoMirrorImage = true;
            this.toolStripAddItemButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripAddItemButton.Text = "Add new";
            this.toolStripAddItemButton.Click += new System.EventHandler(this.toolStripAddItemButton_Click);
            // 
            // toolStripDeleteItemButton
            // 
            this.toolStripDeleteItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDeleteItemButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeleteItemButton.Image")));
            this.toolStripDeleteItemButton.Name = "toolStripDeleteItemButton";
            this.toolStripDeleteItemButton.RightToLeftAutoMirrorImage = true;
            this.toolStripDeleteItemButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripDeleteItemButton.Text = "Delete";
            this.toolStripDeleteItemButton.Click += new System.EventHandler(this.toolStripDeleteItemButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click_1);
            // 
            // deleteIdTextBox
            // 
            this.deleteIdTextBox.Location = new System.Drawing.Point(678, 49);
            this.deleteIdTextBox.Name = "deleteIdTextBox";
            this.deleteIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.deleteIdTextBox.TabIndex = 2;
            this.deleteIdTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(678, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID для удаления";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // postId
            // 
            this.postId.Location = new System.Drawing.Point(15, 226);
            this.postId.Name = "postId";
            this.postId.Size = new System.Drawing.Size(100, 20);
            this.postId.TabIndex = 4;
            this.postId.TextChanged += new System.EventHandler(this.postId_TextChanged);
            // 
            // postHeader
            // 
            this.postHeader.Location = new System.Drawing.Point(121, 226);
            this.postHeader.Name = "postHeader";
            this.postHeader.Size = new System.Drawing.Size(100, 20);
            this.postHeader.TabIndex = 5;
            // 
            // postShortTopic
            // 
            this.postShortTopic.Location = new System.Drawing.Point(227, 226);
            this.postShortTopic.Name = "postShortTopic";
            this.postShortTopic.Size = new System.Drawing.Size(100, 20);
            this.postShortTopic.TabIndex = 6;
            // 
            // postMainTopic
            // 
            this.postMainTopic.Location = new System.Drawing.Point(333, 226);
            this.postMainTopic.Name = "postMainTopic";
            this.postMainTopic.Size = new System.Drawing.Size(100, 20);
            this.postMainTopic.TabIndex = 7;
            // 
            // postUserID
            // 
            this.postUserID.Location = new System.Drawing.Point(436, 226);
            this.postUserID.Name = "postUserID";
            this.postUserID.Size = new System.Drawing.Size(100, 20);
            this.postUserID.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Данные для добавления/изменения";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // filterByAge
            // 
            this.filterByAge.Location = new System.Drawing.Point(681, 128);
            this.filterByAge.Name = "filterByAge";
            this.filterByAge.Size = new System.Drawing.Size(97, 47);
            this.filterByAge.TabIndex = 11;
            this.filterByAge.Text = "Отфильтровать по заголовку";
            this.filterByAge.UseVisualStyleBackColor = true;
            this.filterByAge.Click += new System.EventHandler(this.filterByAge_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(15, 285);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(657, 196);
            this.dataGridView2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Комментарии";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Статьи";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // showAll
            // 
            this.showAll.Location = new System.Drawing.Point(681, 75);
            this.showAll.Name = "showAll";
            this.showAll.Size = new System.Drawing.Size(97, 47);
            this.showAll.TabIndex = 15;
            this.showAll.Text = "Показать все";
            this.showAll.UseVisualStyleBackColor = true;
            this.showAll.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 498);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Пользователи";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(15, 514);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(571, 149);
            this.dataGridView3.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 47);
            this.button1.TabIndex = 18;
            this.button1.Text = "Корневые комментарии";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(681, 285);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 47);
            this.button2.TabIndex = 19;
            this.button2.Text = "Показать все";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(607, 564);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 49);
            this.button3.TabIndex = 20;
            this.button3.Text = "Все пользователи с корневыми комментариями";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(607, 619);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(171, 43);
            this.button4.TabIndex = 21;
            this.button4.Text = "Пользователи со статьями, имеющими комментарии";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(607, 522);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(171, 36);
            this.button5.TabIndex = 22;
            this.button5.Text = "Показать все";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 683);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(123, 39);
            this.button6.TabIndex = 23;
            this.button6.Text = "Пользователи без статей";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(146, 683);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(170, 39);
            this.button7.TabIndex = 24;
            this.button7.Text = "Пользователи со статьями с комментариями";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 764);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.showAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.filterByAge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.postUserID);
            this.Controls.Add(this.postMainTopic);
            this.Controls.Add(this.postShortTopic);
            this.Controls.Add(this.postHeader);
            this.Controls.Add(this.postId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteIdTextBox);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Lab4";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripAddItemButton;
        private System.Windows.Forms.ToolStripButton toolStripDeleteItemButton;
        private System.Windows.Forms.TextBox deleteIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox postId;
        private System.Windows.Forms.TextBox postHeader;
        private System.Windows.Forms.TextBox postShortTopic;
        private System.Windows.Forms.TextBox postMainTopic;
        private System.Windows.Forms.TextBox postUserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button filterByAge;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button showAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

