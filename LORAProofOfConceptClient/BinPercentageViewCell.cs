using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LORAProofOfConceptClient
{
	class BinPercentageViewCell : DataGridViewTextBoxCell
	{
		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
			DataGridViewElementStates cellState, object value, object formattedValue, string errorText,
			DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
		{
			if (value != null)
			{
				if ((bool)value)
				{
					cellStyle.BackColor = Color.LightGreen;
				}
				else
				{
					cellStyle.BackColor = Color.OrangeRed;
				}
			}
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value,
				formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
		}
	}
}
