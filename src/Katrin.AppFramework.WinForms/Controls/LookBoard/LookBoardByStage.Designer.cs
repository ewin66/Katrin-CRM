using System;
using System.Drawing;
using System.Windows.Forms;
namespace Katrin.Win.Common.Controls
{
    partial class LookBoardByStage
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

            if (this._boardsList != null)
                this._boardsList.Clear();
            this._boardsList = null;
            this._bindingSource.Clear();
            this._bindingSource.DataSource = null;
            if (this.boardDataList != null)
                this.boardDataList.Clear();
            this.boardDataList = null;
            this.OnStatusCodeChange = null;
            this.OnValidataStatus = null;
            this.OnCurrentChange = null;
            this.OnEditItem = null;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelRoot = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tableLayoutPanelRoot
            // 
            this.tableLayoutPanelRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tableLayoutPanelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1143F));
            this.tableLayoutPanelRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRoot.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRoot.Name = "tableLayoutPanelRoot";
            this.tableLayoutPanelRoot.RowCount = 1;
            this.tableLayoutPanelRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRoot.Size = new System.Drawing.Size(1143, 524);
            this.tableLayoutPanelRoot.TabIndex = 0;
            this.tableLayoutPanelRoot.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanelRoot_CellPaint);
            // 
            // LookBoardByStage
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelRoot);
            this.LookAndFeel.SkinName = "MetroBlack";
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LookBoardByStage";
            this.Size = new System.Drawing.Size(1143, 524);
            this.ResumeLayout(false);

        }

        #endregion

        //private LookBoardColumn oppColProposed;
        //private LookBoardColumn oppColQualification;
        //private LookBoardColumn oppColNeedsAnalysis;
        //private LookBoardColumn oppColLead;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRoot;

        //private LookBoardColumn oppColNegotiation;
    }
}
