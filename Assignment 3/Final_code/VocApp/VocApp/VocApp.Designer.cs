namespace VocApp
{
    partial class VocApp
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
            this.lbVocApp = new System.Windows.Forms.Label();
            this.dgvCompleteGridView = new System.Windows.Forms.DataGridView();
            this.lbSpelling = new System.Windows.Forms.Label();
            this.lbMeaning = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSpelling = new System.Windows.Forms.TextBox();
            this.tbMeaning = new System.Windows.Forms.TextBox();
            this.tbSampleSentence = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.lbSearchTheWord = new System.Windows.Forms.Label();
            this.tbSearchSpelling = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.lbCompleteView = new System.Windows.Forms.Label();
            this.lbDisplayView = new System.Windows.Forms.Label();
            this.btDeleteRow = new System.Windows.Forms.Button();
            this.lbTimer = new System.Windows.Forms.Label();
            this.btTurnWordsOn = new System.Windows.Forms.Button();
            this.lbSpellingFromEvent = new System.Windows.Forms.Label();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAddFlashWord = new System.Windows.Forms.Button();
            this.btRemoveFlashWord = new System.Windows.Forms.Button();
            this.btSaveFlashWord = new System.Windows.Forms.Button();
            this.cbSortCompleteView = new System.Windows.Forms.ComboBox();
            this.lbSort = new System.Windows.Forms.Label();
            this.tbFlashSpellingDelete = new System.Windows.Forms.TextBox();
            this.lbFlashSpelling = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompleteGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lbVocApp
            // 
            this.lbVocApp.AutoSize = true;
            this.lbVocApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVocApp.Location = new System.Drawing.Point(412, 9);
            this.lbVocApp.Name = "lbVocApp";
            this.lbVocApp.Size = new System.Drawing.Size(162, 46);
            this.lbVocApp.TabIndex = 0;
            this.lbVocApp.Text = "VocApp";
            // 
            // dgvCompleteGridView
            // 
            this.dgvCompleteGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvCompleteGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompleteGridView.Location = new System.Drawing.Point(25, 88);
            this.dgvCompleteGridView.Name = "dgvCompleteGridView";
            this.dgvCompleteGridView.Size = new System.Drawing.Size(562, 205);
            this.dgvCompleteGridView.TabIndex = 1;
            this.dgvCompleteGridView.SelectionChanged += new System.EventHandler(this.dgvCompleteGridView_SelectionChanged);
            // 
            // lbSpelling
            // 
            this.lbSpelling.AutoSize = true;
            this.lbSpelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpelling.Location = new System.Drawing.Point(605, 96);
            this.lbSpelling.Name = "lbSpelling";
            this.lbSpelling.Size = new System.Drawing.Size(58, 17);
            this.lbSpelling.TabIndex = 2;
            this.lbSpelling.Text = "Spelling";
            // 
            // lbMeaning
            // 
            this.lbMeaning.AutoSize = true;
            this.lbMeaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMeaning.Location = new System.Drawing.Point(605, 147);
            this.lbMeaning.Name = "lbMeaning";
            this.lbMeaning.Size = new System.Drawing.Size(62, 17);
            this.lbMeaning.TabIndex = 3;
            this.lbMeaning.Text = "Meaning";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(605, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sentence";
            // 
            // tbSpelling
            // 
            this.tbSpelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSpelling.Location = new System.Drawing.Point(692, 96);
            this.tbSpelling.Name = "tbSpelling";
            this.tbSpelling.Size = new System.Drawing.Size(268, 23);
            this.tbSpelling.TabIndex = 5;
            // 
            // tbMeaning
            // 
            this.tbMeaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMeaning.Location = new System.Drawing.Point(692, 147);
            this.tbMeaning.Name = "tbMeaning";
            this.tbMeaning.Size = new System.Drawing.Size(268, 23);
            this.tbMeaning.TabIndex = 6;
            // 
            // tbSampleSentence
            // 
            this.tbSampleSentence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSampleSentence.Location = new System.Drawing.Point(692, 195);
            this.tbSampleSentence.Name = "tbSampleSentence";
            this.tbSampleSentence.Size = new System.Drawing.Size(268, 23);
            this.tbSampleSentence.TabIndex = 7;
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Location = new System.Drawing.Point(651, 268);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 25);
            this.btSave.TabIndex = 8;
            this.btSave.Text = "AddWord";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(884, 268);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 25);
            this.btCancel.TabIndex = 9;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbSearchTheWord
            // 
            this.lbSearchTheWord.AutoSize = true;
            this.lbSearchTheWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearchTheWord.Location = new System.Drawing.Point(547, 357);
            this.lbSearchTheWord.Name = "lbSearchTheWord";
            this.lbSearchTheWord.Size = new System.Drawing.Size(120, 17);
            this.lbSearchTheWord.TabIndex = 10;
            this.lbSearchTheWord.Text = "Search The Word";
            // 
            // tbSearchSpelling
            // 
            this.tbSearchSpelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchSpelling.Location = new System.Drawing.Point(673, 354);
            this.tbSearchSpelling.Name = "tbSearchSpelling";
            this.tbSearchSpelling.Size = new System.Drawing.Size(199, 23);
            this.tbSearchSpelling.TabIndex = 11;
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearch.Location = new System.Drawing.Point(885, 349);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 25);
            this.btSearch.TabIndex = 12;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // lbCompleteView
            // 
            this.lbCompleteView.AutoSize = true;
            this.lbCompleteView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCompleteView.Location = new System.Drawing.Point(232, 59);
            this.lbCompleteView.Name = "lbCompleteView";
            this.lbCompleteView.Size = new System.Drawing.Size(111, 20);
            this.lbCompleteView.TabIndex = 13;
            this.lbCompleteView.Text = "CompleteView";
            // 
            // lbDisplayView
            // 
            this.lbDisplayView.AutoSize = true;
            this.lbDisplayView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDisplayView.Location = new System.Drawing.Point(756, 62);
            this.lbDisplayView.Name = "lbDisplayView";
            this.lbDisplayView.Size = new System.Drawing.Size(94, 20);
            this.lbDisplayView.TabIndex = 14;
            this.lbDisplayView.Text = "DisplayView";
            // 
            // btDeleteRow
            // 
            this.btDeleteRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteRow.Location = new System.Drawing.Point(25, 305);
            this.btDeleteRow.Name = "btDeleteRow";
            this.btDeleteRow.Size = new System.Drawing.Size(100, 25);
            this.btDeleteRow.TabIndex = 15;
            this.btDeleteRow.Text = "DeleteRow";
            this.btDeleteRow.UseVisualStyleBackColor = true;
            this.btDeleteRow.Click += new System.EventHandler(this.btDeleteRow_Click);
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimer.Location = new System.Drawing.Point(881, 21);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(40, 17);
            this.lbTimer.TabIndex = 16;
            this.lbTimer.Text = "0:0:0";
            // 
            // btTurnWordsOn
            // 
            this.btTurnWordsOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTurnWordsOn.Location = new System.Drawing.Point(148, 305);
            this.btTurnWordsOn.Name = "btTurnWordsOn";
            this.btTurnWordsOn.Size = new System.Drawing.Size(120, 25);
            this.btTurnWordsOn.TabIndex = 17;
            this.btTurnWordsOn.Text = "Turn Words On";
            this.btTurnWordsOn.UseVisualStyleBackColor = true;
            this.btTurnWordsOn.Click += new System.EventHandler(this.btTurnWordsOn_Click);
            // 
            // lbSpellingFromEvent
            // 
            this.lbSpellingFromEvent.AutoSize = true;
            this.lbSpellingFromEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpellingFromEvent.Location = new System.Drawing.Point(41, 394);
            this.lbSpellingFromEvent.Name = "lbSpellingFromEvent";
            this.lbSpellingFromEvent.Size = new System.Drawing.Size(12, 17);
            this.lbSpellingFromEvent.TabIndex = 18;
            this.lbSpellingFromEvent.Text = " ";
            // 
            // btEdit
            // 
            this.btEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEdit.Location = new System.Drawing.Point(760, 268);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(90, 25);
            this.btEdit.TabIndex = 21;
            this.btEdit.Text = "Edit\'N\'Save";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAddFlashWord
            // 
            this.btAddFlashWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddFlashWord.Location = new System.Drawing.Point(274, 305);
            this.btAddFlashWord.Name = "btAddFlashWord";
            this.btAddFlashWord.Size = new System.Drawing.Size(148, 25);
            this.btAddFlashWord.TabIndex = 23;
            this.btAddFlashWord.Text = "Add FlashWord";
            this.btAddFlashWord.UseVisualStyleBackColor = true;
            this.btAddFlashWord.Click += new System.EventHandler(this.btAddFlashWord_Click);
            // 
            // btRemoveFlashWord
            // 
            this.btRemoveFlashWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemoveFlashWord.Location = new System.Drawing.Point(439, 444);
            this.btRemoveFlashWord.Name = "btRemoveFlashWord";
            this.btRemoveFlashWord.Size = new System.Drawing.Size(148, 25);
            this.btRemoveFlashWord.TabIndex = 24;
            this.btRemoveFlashWord.Text = "Remove FlashWord";
            this.btRemoveFlashWord.UseVisualStyleBackColor = true;
            this.btRemoveFlashWord.Click += new System.EventHandler(this.btRemoveFlashWord_Click);
            // 
            // btSaveFlashWord
            // 
            this.btSaveFlashWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveFlashWord.Location = new System.Drawing.Point(428, 305);
            this.btSaveFlashWord.Name = "btSaveFlashWord";
            this.btSaveFlashWord.Size = new System.Drawing.Size(159, 25);
            this.btSaveFlashWord.TabIndex = 25;
            this.btSaveFlashWord.Text = "Save FlashWord";
            this.btSaveFlashWord.UseVisualStyleBackColor = true;
            this.btSaveFlashWord.Click += new System.EventHandler(this.btSaveFlashWord_Click);
            // 
            // cbSortCompleteView
            // 
            this.cbSortCompleteView.FormattingEnabled = true;
            this.cbSortCompleteView.Location = new System.Drawing.Point(466, 61);
            this.cbSortCompleteView.Name = "cbSortCompleteView";
            this.cbSortCompleteView.Size = new System.Drawing.Size(121, 21);
            this.cbSortCompleteView.TabIndex = 26;
            this.cbSortCompleteView.SelectedIndexChanged += new System.EventHandler(this.cbSortCompleteView_SelectedIndexChanged);
            // 
            // lbSort
            // 
            this.lbSort.AutoSize = true;
            this.lbSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSort.Location = new System.Drawing.Point(426, 61);
            this.lbSort.Name = "lbSort";
            this.lbSort.Size = new System.Drawing.Size(34, 17);
            this.lbSort.TabIndex = 27;
            this.lbSort.Text = "Sort";
            // 
            // tbFlashSpellingDelete
            // 
            this.tbFlashSpellingDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFlashSpellingDelete.Location = new System.Drawing.Point(252, 446);
            this.tbFlashSpellingDelete.Name = "tbFlashSpellingDelete";
            this.tbFlashSpellingDelete.Size = new System.Drawing.Size(158, 23);
            this.tbFlashSpellingDelete.TabIndex = 28;
            // 
            // lbFlashSpelling
            // 
            this.lbFlashSpelling.AutoSize = true;
            this.lbFlashSpelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFlashSpelling.Location = new System.Drawing.Point(31, 445);
            this.lbFlashSpelling.Name = "lbFlashSpelling";
            this.lbFlashSpelling.Size = new System.Drawing.Size(209, 17);
            this.lbFlashSpelling.TabIndex = 29;
            this.lbFlashSpelling.Text = "Enter the Flash Word to delete :";
            // 
            // VocApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(993, 507);
            this.Controls.Add(this.lbFlashSpelling);
            this.Controls.Add(this.lbSpellingFromEvent);
            this.Controls.Add(this.btTurnWordsOn);
            this.Controls.Add(this.tbFlashSpellingDelete);
            this.Controls.Add(this.lbSort);
            this.Controls.Add(this.cbSortCompleteView);
            this.Controls.Add(this.btSaveFlashWord);
            this.Controls.Add(this.btRemoveFlashWord);
            this.Controls.Add(this.btAddFlashWord);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.lbTimer);
            this.Controls.Add(this.btDeleteRow);
            this.Controls.Add(this.lbDisplayView);
            this.Controls.Add(this.lbCompleteView);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.tbSearchSpelling);
            this.Controls.Add(this.lbSearchTheWord);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tbSampleSentence);
            this.Controls.Add(this.tbMeaning);
            this.Controls.Add(this.tbSpelling);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMeaning);
            this.Controls.Add(this.lbSpelling);
            this.Controls.Add(this.dgvCompleteGridView);
            this.Controls.Add(this.lbVocApp);
            this.Name = "VocApp";
            this.Text = "VocApp";
            this.Load += new System.EventHandler(this.VocApp_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VocApp_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompleteGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
         
        #endregion

        private System.Windows.Forms.Label lbVocApp;
        private System.Windows.Forms.DataGridView dgvCompleteGridView;
        private System.Windows.Forms.Label lbSpelling;
        private System.Windows.Forms.Label lbMeaning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSpelling;
        private System.Windows.Forms.TextBox tbMeaning;
        private System.Windows.Forms.TextBox tbSampleSentence;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lbSearchTheWord;
        private System.Windows.Forms.TextBox tbSearchSpelling;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Label lbCompleteView;
        private System.Windows.Forms.Label lbDisplayView;
        private System.Windows.Forms.Button btDeleteRow;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Button btTurnWordsOn;
        private System.Windows.Forms.Label lbSpellingFromEvent;
       // private System.Windows.Forms.Label lbMeaningFromEvent;
        //private System.Windows.Forms.Label lbSampleSentFromEvent;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAddFlashWord;
        private System.Windows.Forms.Button btRemoveFlashWord;
        private System.Windows.Forms.Button btSaveFlashWord;
        private System.Windows.Forms.ComboBox cbSortCompleteView;
        private System.Windows.Forms.Label lbSort;
        private System.Windows.Forms.TextBox tbFlashSpellingDelete;
        private System.Windows.Forms.Label lbFlashSpelling;
    }
}

