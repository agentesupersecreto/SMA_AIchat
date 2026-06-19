using System;
using UnityEngine;

namespace Assets.TValle.UI
{
	// Token: 0x020000C2 RID: 194
	[RequireComponent(typeof(Canvas))]
	public abstract class AlwaysOnScreenBase : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x00015021 File Offset: 0x00013221
		public sealed override int updateEvent1Index
		{
			get
			{
				return 42;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x0600056F RID: 1391
		protected abstract Vector3 curretnSorcePosition { get; }

		// Token: 0x06000570 RID: 1392 RVA: 0x00015025 File Offset: 0x00013225
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_Canvas = base.GetComponent<Canvas>();
			this.UpdateScreenPos();
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00015040 File Offset: 0x00013240
		private void UpdateScreenPos()
		{
			Camera camera = this.m_Canvas.worldCamera;
			if (camera == null)
			{
				camera = Camera.main;
			}
			if (camera == null)
			{
				return;
			}
			Transform transform = camera.transform;
			Vector3 curretnSorcePosition = this.curretnSorcePosition;
			if (Vector3.Distance(transform.position, curretnSorcePosition) > this.config.maxDistance)
			{
				return;
			}
			Vector3 vector = curretnSorcePosition + transform.up * this.config.upOffset + transform.right * this.config.rightOffset;
			Vector3 vector2 = camera.WorldToViewportPoint(vector);
			if (vector2.z <= this.config.minZ || vector2.z >= this.config.maxZ || vector2.x <= this.config.minX || vector2.x >= this.config.maxX || vector2.y <= this.config.minY || vector2.y >= this.config.maxY)
			{
				if (vector2.z < 0f)
				{
					if (vector2.y < 0.5f)
					{
						vector2.y = this.config.maxY;
					}
					else
					{
						vector2.y = this.config.minY;
					}
				}
				vector2.x = Mathf.Clamp(vector2.x, this.config.minX, this.config.maxX);
				vector2.y = Mathf.Clamp(vector2.y, this.config.minY, this.config.maxY);
				if (vector2.z < 0f)
				{
					vector2.x = 1f - vector2.x;
				}
				vector2.z = Mathf.Clamp(vector2.z, this.config.minZ, this.config.maxZ);
				vector = camera.ViewportToWorldPoint(vector2);
			}
			this.m_Canvas.transform.position = vector;
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00015254 File Offset: 0x00013454
		public sealed override void OnUpdateEvent1()
		{
			this.UpdateScreenPos();
		}

		// Token: 0x04000215 RID: 533
		private Canvas m_Canvas;

		// Token: 0x04000216 RID: 534
		public AlwaysOnScreenBase.Config config = new AlwaysOnScreenBase.Config();

		// Token: 0x02000196 RID: 406
		[Serializable]
		public class Config
		{
			// Token: 0x04000530 RID: 1328
			public float maxDistance = 15f;

			// Token: 0x04000531 RID: 1329
			public float upOffset = 0.5f;

			// Token: 0x04000532 RID: 1330
			public float rightOffset = 0.05f;

			// Token: 0x04000533 RID: 1331
			public float minX = 0.15f;

			// Token: 0x04000534 RID: 1332
			public float maxX = 0.85f;

			// Token: 0x04000535 RID: 1333
			public float minY = 0.15f;

			// Token: 0x04000536 RID: 1334
			public float maxY = 0.85f;

			// Token: 0x04000537 RID: 1335
			public float minZ = 1.5f;

			// Token: 0x04000538 RID: 1336
			public float maxZ = float.MaxValue;
		}
	}
}
