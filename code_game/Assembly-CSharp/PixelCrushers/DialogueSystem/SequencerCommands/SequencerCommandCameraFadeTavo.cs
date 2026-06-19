using System;
using Assets;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200003A RID: 58
	public class SequencerCommandCameraFadeTavo : SequencerCommand
	{
		// Token: 0x06000121 RID: 289 RVA: 0x0000AD44 File Offset: 0x00008F44
		public void Start()
		{
			try
			{
				string text = base.GetParameter(0, string.Empty).ToLowerInvariant();
				float parameterAsFloat = base.GetParameterAsFloat(1, 2f);
				if (!(text == "in"))
				{
					if (!(text == "out"))
					{
						throw new ArgumentOutOfRangeException(text.ToString());
					}
					CameraFade.FadeOutMain(parameterAsFloat);
				}
				else
				{
					CameraFade.FadeInMain(parameterAsFloat);
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000ADC0 File Offset: 0x00008FC0
		public void Update()
		{
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000ADC2 File Offset: 0x00008FC2
		public void OnDestroy()
		{
		}
	}
}
