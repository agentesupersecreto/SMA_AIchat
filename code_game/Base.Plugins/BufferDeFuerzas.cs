using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
[Serializable]
public class BufferDeFuerzas
{
	// Token: 0x06000132 RID: 306 RVA: 0x00008063 File Offset: 0x00006263
	public void Init(Rigidbody Target, BufferDeFuerzasConfig Config, object targetObj)
	{
		this.m_targetObj = targetObj;
		this.m_target = Target;
		if (Config != null)
		{
			this.config = Config;
		}
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x06000133 RID: 307 RVA: 0x0000807D File Offset: 0x0000627D
	public Rigidbody target
	{
		get
		{
			return this.m_target;
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x06000134 RID: 308 RVA: 0x00008085 File Offset: 0x00006285
	public object targetObj
	{
		get
		{
			return this.m_targetObj;
		}
	}

	// Token: 0x14000001 RID: 1
	// (add) Token: 0x06000135 RID: 309 RVA: 0x00008090 File Offset: 0x00006290
	// (remove) Token: 0x06000136 RID: 310 RVA: 0x000080C8 File Offset: 0x000062C8
	public event BufferDeFuerzas.FuerzaAplicadaHandler onFuerzaAplicada;

	// Token: 0x14000002 RID: 2
	// (add) Token: 0x06000137 RID: 311 RVA: 0x00008100 File Offset: 0x00006300
	// (remove) Token: 0x06000138 RID: 312 RVA: 0x00008138 File Offset: 0x00006338
	public event BufferDeFuerzas.FuerzaAplicadaHandler onFixedUpdated;

	// Token: 0x06000139 RID: 313 RVA: 0x00008170 File Offset: 0x00006370
	public void AddForce(Vector3 point, Vector3 force)
	{
		if (force.sqrMagnitude == 0f)
		{
			return;
		}
		if (this.config.inverse)
		{
			force *= -1f;
		}
		if (this.m_currentFuerza.sqrMagnitude <= 0f)
		{
			this.m_currentFuerza = force;
			this.m_localPoint = this.m_target.transform.InverseTransformPoint(point);
			return;
		}
		float magnitude = this.m_currentFuerza.magnitude;
		float magnitude2 = force.magnitude;
		float num = magnitude + magnitude2;
		this.m_currentFuerza += force;
		Vector3 vector = this.m_target.transform.InverseTransformPoint(point);
		this.m_localPoint = this.m_localPoint * (magnitude / num) + vector * (magnitude2 / num);
	}

	// Token: 0x0600013A RID: 314 RVA: 0x00008235 File Offset: 0x00006435
	public void ResetForces()
	{
		this.m_currentFuerza = Vector3.zero;
		this.m_localPoint = Vector3.zero;
	}

	// Token: 0x0600013B RID: 315 RVA: 0x00008250 File Offset: 0x00006450
	public void DoFixedUpdate(BufferDeFuerzas.FuerzaAplicadaHandler OnFuerzaAplicada = null)
	{
		if (this.m_target == null)
		{
			return;
		}
		Vector3 vector = Vector3.zero;
		Vector3 vector2 = this.m_target.transform.TransformPoint(this.m_localPoint);
		try
		{
			if (this.m_currentFuerza.sqrMagnitude < 0.01f)
			{
				this.m_currentFuerza = Vector3.zero;
				this.m_localPoint = Vector3.zero;
			}
			else
			{
				float num = Mathf.Clamp(this.config.time / Time.fixedDeltaTime, 1f, float.MaxValue);
				vector = this.m_currentFuerza / num;
				try
				{
					Vector3 vector3 = vector * this.config.modificador;
					this.m_target.AddForceAtPosition(vector3, vector2, this.m_debugForceMode);
					bool debugDraw = this.config.debugDraw;
					if (OnFuerzaAplicada != null)
					{
						OnFuerzaAplicada(vector3, vector2, this);
					}
					BufferDeFuerzas.FuerzaAplicadaHandler fuerzaAplicadaHandler = this.onFuerzaAplicada;
					if (fuerzaAplicadaHandler != null)
					{
						fuerzaAplicadaHandler(vector3, vector2, this);
					}
				}
				finally
				{
					this.m_currentFuerza -= vector;
				}
			}
		}
		finally
		{
			BufferDeFuerzas.FuerzaAplicadaHandler fuerzaAplicadaHandler2 = this.onFixedUpdated;
			if (fuerzaAplicadaHandler2 != null)
			{
				fuerzaAplicadaHandler2(vector, vector2, this);
			}
		}
	}

	// Token: 0x0400002B RID: 43
	[SerializeField]
	private Rigidbody m_target;

	// Token: 0x0400002C RID: 44
	[SerializeField]
	private Vector3 m_currentFuerza;

	// Token: 0x0400002D RID: 45
	[SerializeField]
	private Vector3 m_localPoint;

	// Token: 0x0400002E RID: 46
	[SerializeField]
	private ForceMode m_debugForceMode;

	// Token: 0x0400002F RID: 47
	[NonSerialized]
	private object m_targetObj;

	// Token: 0x04000030 RID: 48
	[HideInInspector]
	public BufferDeFuerzasConfig config = new BufferDeFuerzasConfig();

	// Token: 0x02000199 RID: 409
	// (Invoke) Token: 0x06000BDE RID: 3038
	public delegate void FuerzaAplicadaHandler(Vector3 force, Vector3 position, BufferDeFuerzas sender);
}
