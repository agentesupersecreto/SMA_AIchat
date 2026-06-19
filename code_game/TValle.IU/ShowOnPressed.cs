using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000003 RID: 3
public class ShowOnPressed : MonoBehaviour
{
	// Token: 0x06000004 RID: 4 RVA: 0x00002091 File Offset: 0x00000291
	private void Start()
	{
		if (this.m_Toggle == null)
		{
			throw new ArgumentNullException("m_Toggle", "m_Toggle null reference.");
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000020B1 File Offset: 0x000002B1
	private void Update()
	{
		this.m_Graphic.enabled = this.m_Toggle.isOn;
	}

	// Token: 0x04000003 RID: 3
	[SerializeField]
	private Toggle m_Toggle;

	// Token: 0x04000004 RID: 4
	[SerializeField]
	private Graphic m_Graphic;
}
