using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.Penes;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000D8 RID: 216
	[RequireComponent(typeof(BoneStretchedChain))]
	public class CalculadorDePenetracion : MonoBehaviour
	{
		// Token: 0x0600083A RID: 2106 RVA: 0x00019C24 File Offset: 0x00017E24
		private void Awake()
		{
			this.m_Circular8BoneChain = base.GetComponent<BoneStretchedChain>();
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x00019C34 File Offset: 0x00017E34
		public bool TryCastHelper(List<PenisPart> resultPuntas, List<RaycastHit> resultHits, float profundidadMod, out float distancia)
		{
			distancia = 0f;
			int num = 0;
			bool flag;
			try
			{
				if (this.rayTransformConfig.fondo == null || this.rayTransformConfig.entrada == null)
				{
					flag = false;
				}
				else
				{
					Vector3 forward = this.rayTransformConfig.entrada.forward;
					Vector3 position = this.rayTransformConfig.entrada.position;
					float num2 = (distancia = Vector3.Distance(this.rayTransformConfig.fondo.position, this.rayTransformConfig.entrada.position) * profundidadMod);
					float num3 = Mathf.Max(0.01f, this.rayConfig.ancho * 0.5f);
					num = PhysicsCast.SphereCastNonAlloc(position, num3, forward, this.m_resultsTemp, num2, this.rayConfig.layerMaskHelper, QueryTriggerInteraction.Ignore);
					if (num > 0)
					{
						for (int i = 0; i < num; i++)
						{
							RaycastHit raycastHit = this.m_resultsTemp[i];
							if (!(raycastHit.rigidbody == null))
							{
								PenisPart component = raycastHit.rigidbody.GetComponent<PenisPart>();
								if (!(component == null) && this.m_PArtesTemp.Add(component))
								{
									resultHits.Add(raycastHit);
									resultPuntas.Add(component);
								}
							}
						}
					}
					if (this.isDebugHelper)
					{
						foreach (RaycastHit raycastHit2 in resultHits)
						{
						}
					}
					flag = num > 0;
				}
			}
			finally
			{
				this.m_PArtesTemp.Clear();
				Array.Clear(this.m_resultsTemp, 0, num);
			}
			return flag;
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00019DFC File Offset: 0x00017FFC
		public bool TryEncontrarCercano(out IPene pene)
		{
			int num = 0;
			bool flag;
			try
			{
				Vector3 position = this.rayTransformConfig.entrada.position;
				float num2 = Vector3.Distance(this.rayTransformConfig.fondo.position, this.rayTransformConfig.entrada.position) * 2f;
				num = Physics.OverlapSphereNonAlloc(position, num2, this.m_resultsColliderTemp, this.rayConfig.layerMaskPenesInHole, QueryTriggerInteraction.Collide);
				if (num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						Rigidbody attachedRigidbody = this.m_resultsColliderTemp[i].attachedRigidbody;
						if (!(attachedRigidbody == null))
						{
							PenisPart component = attachedRigidbody.GetComponent<PenisPart>();
							if (!(component == null) && component.pene != null)
							{
								pene = component.pene;
								return true;
							}
						}
					}
				}
				pene = null;
				flag = false;
			}
			finally
			{
				Array.Clear(this.m_resultsColliderTemp, 0, num);
			}
			return flag;
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00019EE0 File Offset: 0x000180E0
		public bool TryCastMultipleTrayecto([TupleElementNames(new string[] { "start", "end", "radius" })] IReadOnlyList<ValueTuple<Vector3, Vector3, float>> trayectos, PenetradorHits result)
		{
			bool flag = false;
			bool flag2;
			try
			{
				((ILimpiarPenisHit)result).Limpiar();
				if (trayectos == null || trayectos.Count == 0)
				{
					flag2 = flag;
				}
				else
				{
					float num = 0f;
					for (int i = 0; i < trayectos.Count; i++)
					{
						ValueTuple<Vector3, Vector3, float> valueTuple = trayectos[i];
						Vector3 normalized = (valueTuple.Item2 - valueTuple.Item1).normalized;
						Vector3 vector = valueTuple.Item1 + -normalized * valueTuple.Item3;
						float num2 = Vector3.Distance(valueTuple.Item1, valueTuple.Item2);
						int num3 = 0;
						try
						{
							num3 = PhysicsCast.SphereCastNonAlloc(vector, valueTuple.Item3, normalized, this.m_resultsTemp, num2, this.rayConfig.layerMaskPenesInHole, QueryTriggerInteraction.Collide);
							if (num3 != 0)
							{
								for (int j = 0; j < num3; j++)
								{
									RaycastHit raycastHit = this.m_resultsTemp[j];
									if (raycastHit.distance != 0f)
									{
										raycastHit.distance += num;
										this.m_resultsTemp[j] = raycastHit;
									}
								}
								CalculadorDePenetracion.LimpiarDic(this.m_resultRigidsTemp);
								CalculadorDePenetracion.ClasificarRigidHit(this.m_resultRigidsTemp, num3, this.m_resultsTemp, valueTuple.Item1, valueTuple.Item3, normalized);
								if (this.m_resultRigidsTemp.Count != 0)
								{
									CalculadorDePenetracion.ClasificarPartHit(this.m_resultRigidsTemp, this.m_resultPenisesDicTemp);
									int count = this.m_resultPenisesDicTemp.Count;
								}
							}
						}
						finally
						{
							if (this.isDebugHayPenes)
							{
								Debug.DrawLine(vector, vector + normalized * num2, Color.red, 0f, false);
								for (int k = 0; k < num3; k++)
								{
									RaycastHit raycastHit2 = this.m_resultsTemp[k];
									Debug.DrawLine(vector, vector + normalized * (raycastHit2.distance - num), Color.green, 0f, false);
								}
							}
							num += num2;
							Array.Clear(this.m_resultsTemp, 0, num3);
						}
					}
					foreach (KeyValuePair<PenisPart, RaycastHit> keyValuePair in this.m_resultPenisesDicTemp)
					{
						PenisPart key = keyValuePair.Key;
						RaycastHit value = keyValuePair.Value;
						PenisPart penisPart = key;
						if (penisPart == null)
						{
							throw new NotSupportedException();
						}
						if (((IPenisPartPenetrationValidator)penisPart).IsValid(key, this.m_Circular8BoneChain, value) && (!key.inside || key.currentPenetratingHole == this.m_Circular8BoneChain))
						{
							this.m_resultPenisesDicTempValidados.Add(key, value);
						}
					}
					if (this.m_resultPenisesDicTempValidados.Count == 0)
					{
						flag2 = flag;
					}
					else
					{
						((IAñadirPenisHit)result).Añadir(this.m_resultPenisesDicTempValidados, num, this.m_resultPenisesDicTemp.Count);
						flag = result.count > 0;
						flag2 = flag;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Exepcion en CalculadorDePenetracion.TryCastMultipleTrayecto.", base.gameObject);
				throw ex;
			}
			finally
			{
				this.m_resultPenisesDicTemp.Clear();
				this.m_resultRigidsTemp.Clear();
				this.m_resultPenisesDicTempValidados.Clear();
			}
			return flag2;
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x0001A248 File Offset: 0x00018448
		public bool TryCast(PenetradorHits result)
		{
			Vector3 zero = Vector3.zero;
			float num = 0f;
			Vector3 vector = Vector3.zero;
			bool flag = false;
			int num2 = 0;
			bool flag2;
			try
			{
				((ILimpiarPenisHit)result).Limpiar();
				if (this.rayTransformConfig.fondo == null || this.rayTransformConfig.entrada == null)
				{
					flag2 = flag;
				}
				else
				{
					Vector3 position = this.rayTransformConfig.entrada.position;
					Vector3 position2 = this.rayTransformConfig.fondo.position;
					float num3 = this.rayConfig.ancho * 0.5f;
					vector = (position - position2).normalized;
					Vector3 vector2 = position2 + -vector * num3;
					num = Vector3.Distance(vector2, position);
					num2 = PhysicsCast.SphereCastNonAlloc(vector2, num3, vector, this.m_resultsTemp, num, this.rayConfig.layerMaskPenesInHole, QueryTriggerInteraction.Collide);
					if (num2 == 0)
					{
						flag2 = flag;
					}
					else
					{
						CalculadorDePenetracion.LimpiarDic(this.m_resultRigidsTemp);
						CalculadorDePenetracion.ClasificarRigidHit(this.m_resultRigidsTemp, num2, this.m_resultsTemp, position2, num3, vector);
						if (this.m_resultRigidsTemp.Count == 0)
						{
							flag2 = flag;
						}
						else
						{
							CalculadorDePenetracion.LimpiarDic(this.m_resultPenisesDicTemp);
							CalculadorDePenetracion.ClasificarPartHit(this.m_resultRigidsTemp, this.m_resultPenisesDicTemp);
							if (this.m_resultPenisesDicTemp.Count == 0)
							{
								flag2 = flag;
							}
							else
							{
								foreach (KeyValuePair<PenisPart, RaycastHit> keyValuePair in this.m_resultPenisesDicTemp)
								{
									PenisPart key = keyValuePair.Key;
									RaycastHit value = keyValuePair.Value;
									PenisPart penisPart = key;
									if (penisPart == null)
									{
										throw new NotSupportedException();
									}
									if (((IPenisPartPenetrationValidator)penisPart).IsValid(key, this.m_Circular8BoneChain, value) && (!key.inside || key.currentPenetratingHole == this.m_Circular8BoneChain))
									{
										this.m_resultPenisesDicTempValidados.Add(key, value);
									}
								}
								if (this.m_resultPenisesDicTempValidados.Count == 0)
								{
									flag2 = flag;
								}
								else
								{
									((IAñadirPenisHit)result).Añadir(this.m_resultPenisesDicTempValidados, num, this.m_resultPenisesDicTemp.Count);
									flag = result.count > 0;
									flag2 = flag;
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Exepcion en CalculadorDePenetracion.TryCast.", base.gameObject);
				throw ex;
			}
			finally
			{
				if (this.isDebugHayPenes && flag)
				{
					Vector3 position3 = this.rayTransformConfig.fondo.position;
					for (int i = 0; i < result.count; i++)
					{
						PenisPartHit penisPartHit = result[i];
					}
				}
				this.m_resultPenisesDicTemp.Clear();
				this.m_resultRigidsTemp.Clear();
				this.m_resultPenisesDicTempValidados.Clear();
				Array.Clear(this.m_resultsTemp, 0, num2);
			}
			return flag2;
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x0001A528 File Offset: 0x00018728
		private static void ClasificarRigidHit(Dictionary<Rigidbody, RaycastHit> result, int cantidad, RaycastHit[] hits, Vector3 origin, float castRadius, Vector3 castDirection)
		{
			for (int i = 0; i < cantidad; i++)
			{
				RaycastHit raycastHit = hits[i];
				Rigidbody attachedRigidbody = raycastHit.collider.attachedRigidbody;
				if (!(attachedRigidbody == null))
				{
					if (raycastHit.distance == 0f && raycastHit.point == Vector3.zero)
					{
						bool queriesHitBackfaces = Physics.queriesHitBackfaces;
						bool flag;
						try
						{
							Physics.queriesHitBackfaces = false;
							float num = castRadius * 2f * 1.00001f;
							Vector3 vector = origin - castDirection * num;
							Ray ray = new Ray(vector, castDirection);
							RaycastHit raycastHit2;
							flag = raycastHit.collider.Raycast(ray, out raycastHit2, num);
						}
						finally
						{
							Physics.queriesHitBackfaces = queriesHitBackfaces;
						}
						if (!flag)
						{
							goto IL_00DE;
						}
						raycastHit.point = origin;
					}
					if (result.ContainsKey(attachedRigidbody))
					{
						if (result[attachedRigidbody].distance > raycastHit.distance)
						{
							result[attachedRigidbody] = raycastHit;
						}
					}
					else
					{
						result.Add(attachedRigidbody, raycastHit);
					}
				}
				IL_00DE:;
			}
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x0001A630 File Offset: 0x00018830
		private static void ClasificarPartHit(Dictionary<Rigidbody, RaycastHit> rigidsHits, Dictionary<PenisPart, RaycastHit> result)
		{
			foreach (KeyValuePair<Rigidbody, RaycastHit> keyValuePair in rigidsHits)
			{
				Component key = keyValuePair.Key;
				RaycastHit value = keyValuePair.Value;
				PenisPart component = key.GetComponent<PenisPart>();
				if (!(component == null))
				{
					if (result.ContainsKey(component))
					{
						if (result[component].distance > value.distance)
						{
							result[component] = value;
						}
					}
					else
					{
						result.Add(component, value);
					}
				}
			}
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x0001A6CC File Offset: 0x000188CC
		private static void LimpiarDic(IDictionary dic)
		{
			if (dic != null && dic.Count > 0)
			{
				dic.Clear();
			}
		}

		// Token: 0x04000482 RID: 1154
		public CalculadorDePenetracion.RayTransformConfig rayTransformConfig = new CalculadorDePenetracion.RayTransformConfig();

		// Token: 0x04000483 RID: 1155
		public CalculadorDePenetracion.RayConfig rayConfig = new CalculadorDePenetracion.RayConfig();

		// Token: 0x04000484 RID: 1156
		private Collider[] m_resultsColliderTemp = new Collider[100];

		// Token: 0x04000485 RID: 1157
		private RaycastHit[] m_resultsTemp = new RaycastHit[100];

		// Token: 0x04000486 RID: 1158
		private static RaycastHit[] m_GlobalresultsTemp = new RaycastHit[100];

		// Token: 0x04000487 RID: 1159
		private Dictionary<Rigidbody, RaycastHit> m_resultRigidsTemp = new Dictionary<Rigidbody, RaycastHit>();

		// Token: 0x04000488 RID: 1160
		private Dictionary<PenisPart, RaycastHit> m_resultPenisesDicTemp = new Dictionary<PenisPart, RaycastHit>();

		// Token: 0x04000489 RID: 1161
		private Dictionary<PenisPart, RaycastHit> m_resultPenisesDicTempValidados = new Dictionary<PenisPart, RaycastHit>();

		// Token: 0x0400048A RID: 1162
		private HashSet<PenisPart> m_PArtesTemp = new HashSet<PenisPart>();

		// Token: 0x0400048B RID: 1163
		public bool isDebugHelper;

		// Token: 0x0400048C RID: 1164
		public bool isDebugHayPenes;

		// Token: 0x0400048D RID: 1165
		private BoneStretchedChain m_Circular8BoneChain;

		// Token: 0x020001AF RID: 431
		[Serializable]
		public class RayTransformConfig
		{
			// Token: 0x040009B7 RID: 2487
			public Transform fondo;

			// Token: 0x040009B8 RID: 2488
			public Transform entrada;
		}

		// Token: 0x020001B0 RID: 432
		[Serializable]
		public class RayConfig
		{
			// Token: 0x040009B9 RID: 2489
			public LayerMask layerMaskHelper = -1;

			// Token: 0x040009BA RID: 2490
			public LayerMask layerMaskPenesInHole = -1;

			// Token: 0x040009BB RID: 2491
			public float ancho = 0.02f;
		}
	}
}
