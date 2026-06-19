using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime
{
	// Token: 0x020000C8 RID: 200
	[RequireComponent(typeof(Text))]
	public class FontDisableSmooth : MonoBehaviour
	{
		// Token: 0x0600059E RID: 1438 RVA: 0x00015A6D File Offset: 0x00013C6D
		private void Start()
		{
			base.GetComponent<Text>().font.material.mainTexture.filterMode = FilterMode.Point;
		}

		// Token: 0x04000223 RID: 547
		private Text m_test;
	}
}
