using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.UI.Interacciones.Donas
{
	// Token: 0x02000023 RID: 35
	public class GenericCheckerIsGrayOut : CustomMonobehaviour
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x00004A6C File Offset: 0x00002C6C
		public void OnCheckGreyOut(EsGreyOutEventArgs args, object sender)
		{
			if (args.esGreyOut)
			{
				return;
			}
			try
			{
				base.transform.GetComponents<ICheckerIsGreyOut>(GenericCheckerIsGrayOut.m_Checkers);
				for (int i = 0; i < GenericCheckerIsGrayOut.m_Checkers.Count; i++)
				{
					ICheckerIsGreyOut checkerIsGreyOut = GenericCheckerIsGrayOut.m_Checkers[i];
					if (((checkerIsGreyOut != null) ? new bool?(checkerIsGreyOut.isGreyOut) : null).GetValueOrDefault(false))
					{
						args.esGreyOut = true;
						if (this.greyedOutEsHidden)
						{
							args.greyedOutEsInvisible = true;
						}
						break;
					}
				}
			}
			finally
			{
				GenericCheckerIsGrayOut.m_Checkers.Clear();
			}
		}

		// Token: 0x0400007A RID: 122
		public bool greyedOutEsHidden;

		// Token: 0x0400007B RID: 123
		private static List<ICheckerIsGreyOut> m_Checkers = new List<ICheckerIsGreyOut>();
	}
}
