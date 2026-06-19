using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.UI.Interacciones.Donas
{
	// Token: 0x02000024 RID: 36
	public class GenericCheckerIsOverrideDescription : CustomMonobehaviour
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x00004B20 File Offset: 0x00002D20
		public void OnCheckIsOverrideDescription(DescriptionOverridedEventArgs args, object sender)
		{
			try
			{
				base.transform.GetComponents<IOverriderDescription>(GenericCheckerIsOverrideDescription.m_Checkers);
				for (int i = 0; i < GenericCheckerIsOverrideDescription.m_Checkers.Count; i++)
				{
					IOverriderDescription overriderDescription = GenericCheckerIsOverrideDescription.m_Checkers[i];
					string text = ((overriderDescription != null) ? overriderDescription.descriptionOverriding : null);
					if (!string.IsNullOrWhiteSpace(text))
					{
						if (!string.IsNullOrWhiteSpace(args.description))
						{
							args.description = args.description + "\n" + text;
						}
						else
						{
							args.description = text;
						}
					}
				}
			}
			finally
			{
				GenericCheckerIsOverrideDescription.m_Checkers.Clear();
			}
		}

		// Token: 0x0400007C RID: 124
		private static List<IOverriderDescription> m_Checkers = new List<IOverriderDescription>();
	}
}
