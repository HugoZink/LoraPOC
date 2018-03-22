using LORAProofOfConcept.Core;
using LORAProofOfConceptClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LORAProofOfConceptClient
{
	public partial class MainForm : Form
	{
		private GarbageBinService garbageBinService;

		private List<GarbageBin> bins;

		public MainForm()
		{
			InitializeComponent();

			this.garbageBinService = new GarbageBinService();
			this.bins = new List<GarbageBin>();

			InitializeBinsList();
			GetBins();


		}

		private void InitializeBinsList()
		{
			binsGridView.AutoGenerateColumns = false;

			var IDCol = new DataGridViewTextBoxColumn();
			IDCol.HeaderText = "Bin ID";
			IDCol.DataPropertyName = "ID";
			binsGridView.Columns.Add(IDCol);

			var capacityCol = new DataGridViewTextBoxColumn();
			capacityCol.HeaderText = "Full percentage";
			capacityCol.DataPropertyName = "CurrentCapacity";
			binsGridView.Columns.Add(capacityCol);

			binsGridView.DataSource = this.bins;
		}

		private async void GetBins()
		{
			this.bins = await this.garbageBinService.GetGarbageBins();

			this.binsGridView.DataSource = this.bins;
			this.binsGridView.Update();
			this.binsGridView.Refresh();
		}

		private void ShowDetailsForBin(GarbageBin bin)
		{
			IDTextBox.Text = bin.ID;
			latTextBox.Text = bin.Latitude;
			longTextBox.Text = bin.Longitude;
			capacityTextBox.Text = bin.FullPercentage.ToString();

			if(bin.FullPercentage > 80)
			{
				statusText.Text = "Deze vuilnisbak is bijna vol.";
			}
			else
			{
				statusText.Text = "Deze vuilnisbak hoeft nog niet geleegd te worden.";
			}
		}

		private void binsGridView_SelectionChanged(object sender, EventArgs e)
		{
			// Find the bin that was clicked on
			int index = binsGridView.CurrentCell.RowIndex;
			GarbageBin bin = this.bins[index];

			// Fill out details for bin
			ShowDetailsForBin(bin);
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			this.GetBins();
		}

		private void refreshTimer_Tick(object sender, EventArgs e)
		{
			this.GetBins();
		}
	}
}
