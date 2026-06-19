using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Puntos;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.TValle.BeachGirl.Runtime.Semens
{
	// Token: 0x0200006D RID: 109
	public sealed class EmisorDeSemenChain : AplicableCustomMonobehaviour
	{
		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060001FE RID: 510 RVA: 0x000053C9 File Offset: 0x000035C9
		public Vector3 direccionDeEmision
		{
			get
			{
				return -base.transform.forward;
			}
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060001FF RID: 511 RVA: 0x000053DC File Offset: 0x000035DC
		// (remove) Token: 0x06000200 RID: 512 RVA: 0x00005414 File Offset: 0x00003614
		public event Action<SemenChain, EmisorDeSemenChain> onChainCreated;

		// Token: 0x06000201 RID: 513 RVA: 0x00005449 File Offset: 0x00003649
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00005451 File Offset: 0x00003651
		public SemenChain EmitirAnonimus()
		{
			return this.EmitirDesdePene(null, null, null, null);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000545D File Offset: 0x0000365D
		public void EmitirTesting()
		{
			this.EmitirDesdePene(null, null, null, null);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000546A File Offset: 0x0000366A
		public static float ParticleScale(IPeneSimple pene)
		{
			return Mathf.Lerp(pene.worldScale / 0.75f, 1f, 0.8f);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00005487 File Offset: 0x00003687
		public static float ParticleScale(IHole hole)
		{
			return hole.worldScaleReal;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00005490 File Offset: 0x00003690
		public static float GetParticleVolumenAproxV2(IHole hole, ref EmisorDeSemenChain.NextEmisionConfig config, EmisorDeSemenChain emisor)
		{
			return Mathf.Clamp(Mathf.Pow(EmisorDeSemenChain.ParticleScale(hole) * config.scale * Mathf.Max(config.maxScale, config.minScale) * emisor.semenPuntoConfig.colliderRadius * 100f * 2f, 3f), 0.01f, 1000f);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x000054F0 File Offset: 0x000036F0
		public static float GetParticleVolumenAproxV2(IPeneSimple pene, ref EmisorDeSemenChain.NextEmisionConfig config, EmisorDeSemenChain emisor)
		{
			return Mathf.Clamp(Mathf.Pow(EmisorDeSemenChain.ParticleScale(pene) * config.scale * Mathf.Max(config.maxScale, config.minScale) * emisor.semenPuntoConfig.colliderRadius * 100f * 2f, 3f), 0.01f, 1000f);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000554D File Offset: 0x0000374D
		public static float GetParticleDefaultVolumenAproxV2()
		{
			return Mathf.Pow(0.4f, 3f);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00005560 File Offset: 0x00003760
		public void EmitirDesdePeneConOverflow(IPeneSimple Owner, Object sender, int overflow, Func<Vector3> positionGetter = null, Func<Quaternion> rotationGetter = null)
		{
			if (Owner == null)
			{
				Owner = CurrentMainCharacter<CurrentMainChar, MainChar>.current.GetComponentInChildren<IPeneSimple>();
			}
			float num = EmisorDeSemenChain.ParticleScale(Owner);
			float num2 = Mathf.Lerp(Owner.worldScale, 1f, 0.85f);
			if (positionGetter != null)
			{
				base.transform.position = positionGetter();
			}
			if (rotationGetter != null)
			{
				base.transform.rotation = rotationGetter() * Quaternion.AngleAxis(180f, Vector3.up);
			}
			this.emitir(Owner.inmediateOwner, sender, Owner, num, num2, new Action<List<Collider>>(Owner.GetColliders), new float?(Owner.worldMaxWidth * 2f), this.next);
			for (int i = 0; i < overflow; i++)
			{
				this.emitir(Owner.inmediateOwner, sender, Owner, num, num2, new Action<List<Collider>>(Owner.GetColliders), new float?(Owner.worldMaxWidth * 2f), this.next);
			}
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00005650 File Offset: 0x00003850
		public SemenChain EmitirDesdePene(IPeneSimple Owner, Object sender, Func<Vector3> positionGetter = null, Func<Quaternion> rotationGetter = null)
		{
			if (Owner == null)
			{
				Owner = CurrentMainCharacter<CurrentMainChar, MainChar>.current.GetComponentInChildren<IPeneSimple>();
			}
			float num = EmisorDeSemenChain.ParticleScale(Owner);
			float num2 = Mathf.Lerp(Owner.worldScale, 1f, 0.85f);
			if (positionGetter != null)
			{
				base.transform.position = positionGetter();
			}
			if (rotationGetter != null)
			{
				base.transform.rotation = rotationGetter() * Quaternion.AngleAxis(180f, Vector3.up);
			}
			return this.emitir(Owner.inmediateOwner, sender, Owner, num, num2, new Action<List<Collider>>(Owner.GetColliders), new float?(Owner.worldMaxWidth * 2f), this.next);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x000056FC File Offset: 0x000038FC
		public SemenChain EmitirDesdeHole(ICharacter Owner, Object sender, IHole from, Func<Vector3> positionGetter = null, Func<Quaternion> rotationGetter = null)
		{
			if (Owner == null)
			{
				Owner = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character;
			}
			float num = EmisorDeSemenChain.ParticleScale(from);
			float num2 = Mathf.Lerp(from.worldScaleReal, 1f, 0.85f);
			if (positionGetter != null)
			{
				base.transform.position = positionGetter();
			}
			if (rotationGetter != null)
			{
				base.transform.rotation = rotationGetter() * Quaternion.AngleAxis(180f, Vector3.up);
			}
			return this.emitir(Owner, sender, null, num, num2, new Action<List<Collider>>(from.GetWallColliders), null, this.next);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000579C File Offset: 0x0000399C
		public GameObject GetParticle(Vector3 position, Quaternion rotation)
		{
			return Object.Instantiate<GameObject>(this.puntoPrefab, position, rotation);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x000057AC File Offset: 0x000039AC
		private SemenChain emitir(ICharacter Owner, Object sender, IPeneSimple Pene, float scaleMod, float velMod, Action<List<Collider>> collidersToIgnoreLoader, float? rangoDeCorreccion, EmisorDeSemenChain.NextEmisionConfig emitConfig)
		{
			SemenChain semenChain = new GameObject("SemenChain").AddComponent<SemenChain>();
			SceneManager.MoveGameObjectToScene(semenChain.gameObject, Owner.rootBoneTransform.gameObject.scene);
			semenChain.SetManualStart();
			semenChain.transform.SetPositionAndRotation(base.transform.position, base.transform.rotation);
			semenChain.transform.localScale = Vector3.one * scaleMod;
			List<Transform> list = new List<Transform>();
			float num = this.semenPuntoConfig.colliderRadius * 2f;
			float num2 = 0f;
			for (int i = 0; i < emitConfig.count; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.puntoPrefab, semenChain.transform.position, semenChain.transform.rotation, semenChain.transform);
				float num3 = emitConfig.scale * Mathf.Lerp(emitConfig.minScale, emitConfig.maxScale, Mathf.InverseLerp((float)(emitConfig.count - 1), 0f, (float)i).OutPow(emitConfig.scaleOutPower));
				if (emitConfig.scaleRandomization > 0f)
				{
					num3 = Random.Range(Mathf.Lerp(num3, num3 * 0.5f, emitConfig.scaleRandomization), Mathf.Lerp(num3, num3 * 2f, emitConfig.scaleRandomization));
				}
				float num4 = num * num3;
				gameObject.transform.localScale = new Vector3(num3, num3, num3);
				gameObject.transform.localPosition = new Vector3(0f, 0f, num2);
				list.Add(gameObject.transform);
				num2 += num4;
			}
			semenChain.SetReferences(this.puntosConfig, this.semenPuntoConfig, this.tipo, Owner, Pene, this, sender, list);
			semenChain.ManualStart();
			Action<SemenChain, EmisorDeSemenChain> action = this.onChainCreated;
			if (action != null)
			{
				action(semenChain, this);
			}
			try
			{
				if (collidersToIgnoreLoader != null)
				{
					collidersToIgnoreLoader(EmisorDeSemenChain.m_TempPenisColliders);
				}
				for (int j = 0; j < semenChain.semenPuntos.Count; j++)
				{
					SemenPunto semenPunto = semenChain.semenPuntos[j];
					ExtendedMonoBehaviour.IgnorarCollisionesV2(semenPunto.semenCollider, EmisorDeSemenChain.m_TempPenisColliders, true);
					float num5 = velMod * Mathf.Lerp(emitConfig.minVelocity, emitConfig.maxVelocity, Mathf.InverseLerp((float)(semenChain.semenPuntos.Count - 1), 0f, (float)j).OutPow(emitConfig.impulseOutPower));
					if (emitConfig.velocityRandomization > 0f)
					{
						num5 = Random.Range(Mathf.Lerp(num5, num5 * 0.5f, emitConfig.velocityRandomization), Mathf.Lerp(num5, num5 * 2f, emitConfig.velocityRandomization));
					}
					Vector3 vector = this.direccionDeEmision;
					if (emitConfig.velocityDirectionRandomization > 0f)
					{
						Vector3 vector2 = base.transform.rotation * -MathfExtension.RandomLocalDirection(emitConfig.velocityDirectionRandomizationMinAngle, emitConfig.velocityDirectionRandomizationMaxAngle);
						vector = Vector3.Lerp(vector, vector2, emitConfig.velocityDirectionRandomization);
					}
					semenPunto.distanceToBreakMod = emitConfig.distanceToBreakMod;
					semenPunto.ChangeVelocity(vector, num5);
					float num6 = scaleMod * Mathf.Lerp(emitConfig.minWaitToBind, emitConfig.maxWaitToBind, Mathf.InverseLerp((float)(semenChain.semenPuntos.Count - 1), 0f, (float)j).OutPow(emitConfig.waitToBindOutPower));
					if (emitConfig.waitToBindRandomization > 0f)
					{
						num6 = Random.Range(Mathf.Lerp(num6, num6 * 0.5f, emitConfig.waitToBindRandomization), Mathf.Lerp(num6, num6 * 2f, emitConfig.waitToBindRandomization));
					}
					semenPunto.SetWaitToBind(num6);
				}
			}
			finally
			{
				EmisorDeSemenChain.m_TempPenisColliders.Clear();
			}
			if (emitConfig.corregirTrayectoria)
			{
				GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.meshGeneralModsUpdate1, this, this.CorregirTrayectoriaRutine(semenChain, base.transform, emitConfig), null);
			}
			else
			{
				for (int k = 0; k < semenChain.semenPuntos.Count; k++)
				{
					SemenPunto semenPunto2 = semenChain.semenPuntos[k];
					semenPunto2.StartCheckDuration();
					semenPunto2.StartWaitToBind();
				}
			}
			return semenChain;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00005BCC File Offset: 0x00003DCC
		private void ProyectToInternals(IHoleInternals holeInternals, Rigidbody body)
		{
			body.transform.position = holeInternals.ProyectTo(body.transform.position);
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00005BEA File Offset: 0x00003DEA
		private IEnumerator CorregirTrayectoriaRutine(SemenChain chain, Transform emisor, EmisorDeSemenChain.NextEmisionConfig emitionConfig)
		{
			IHole componentInParent = emisor.GetComponentInParent<IHole>();
			IHoleInternals holeInternals = ((componentInParent != null) ? componentInParent.internals : null);
			bool tieneInternals = holeInternals != null;
			List<SemenPunto> puntos = chain.semenPuntos.ToList<SemenPunto>();
			List<ModificadorDeBool> m_puedeHacerBindAnds = new List<ModificadorDeBool>();
			List<int> m_puntosCollidersLayers = new List<int>();
			List<float> m_puntosMaxTimeToReachEmitor = new List<float>();
			List<float> m_puntosDefaultDrags = new List<float>();
			List<Vector3> m_puntosStartPointsLocales = new List<Vector3>();
			for (int i = 0; i < puntos.Count; i++)
			{
				SemenPunto semenPunto = puntos[i];
				m_puedeHacerBindAnds.Add(semenPunto.puedeHacerBindAnd.ObtenerModificadorNotNull(emisor));
				m_puntosCollidersLayers.Add(semenPunto.semenCollider.gameObject.layer);
				m_puntosMaxTimeToReachEmitor.Add(Mathf.Clamp((emisor.position - semenPunto.bodyTransform.position).magnitude / emitionConfig.minVelocity, float.Epsilon, float.MaxValue));
				m_puntosStartPointsLocales.Add(emisor.InverseTransformPoint(semenPunto.bodyTransform.position));
				if (semenPunto.body != null)
				{
					m_puntosDefaultDrags.Add(semenPunto.body.drag);
					if (tieneInternals)
					{
						this.ProyectToInternals(holeInternals, semenPunto.body);
						semenPunto.SendVisualToLayer(ConfiguracionGlobal.layersStatic.transparentFX);
					}
				}
			}
			float startTime = Time.time;
			yield return null;
			while (!(emisor == null))
			{
				bool todosLosPuntosFueraDeEmisor = true;
				float num = Time.time - startTime;
				Vector3 vector = -emisor.forward;
				Vector3 position = emisor.position;
				for (int j = puntos.Count - 1; j >= 0; j--)
				{
					SemenPunto semenPunto2 = puntos[j];
					ModificadorDeBool modificadorDeBool = m_puedeHacerBindAnds[j];
					modificadorDeBool.valor.valor = true;
					if (semenPunto2 == null || semenPunto2.isBinded || semenPunto2.isManualMode)
					{
						modificadorDeBool.TryRemoverDeOwner(true);
						m_puntosCollidersLayers.RemoveAt(j);
						m_puedeHacerBindAnds.RemoveAt(j);
						puntos.RemoveAt(j);
						m_puntosMaxTimeToReachEmitor.RemoveAt(j);
						m_puntosStartPointsLocales.RemoveAt(j);
						m_puntosDefaultDrags.RemoveAt(j);
					}
					else
					{
						if (semenPunto2.semenCollider != null)
						{
							semenPunto2.semenCollider.gameObject.layer = m_puntosCollidersLayers[j];
						}
						semenPunto2.DisableVisual(false);
						Rigidbody body = semenPunto2.body;
						if (body == null || body.isKinematic)
						{
							modificadorDeBool.TryRemoverDeOwner(true);
							m_puntosCollidersLayers.RemoveAt(j);
							m_puedeHacerBindAnds.RemoveAt(j);
							puntos.RemoveAt(j);
							m_puntosMaxTimeToReachEmitor.RemoveAt(j);
							m_puntosStartPointsLocales.RemoveAt(j);
							m_puntosDefaultDrags.RemoveAt(j);
							semenPunto2.StartCheckDuration();
							semenPunto2.StartWaitToBind();
						}
						else
						{
							body.useGravity = true;
							body.drag = m_puntosDefaultDrags[j];
							Vector3 vector2 = position + vector * semenPunto2.particleWorldRarius;
							if (Vector3.Dot(vector, (vector2 - body.transform.position).normalized) < 0f)
							{
								modificadorDeBool.TryRemoverDeOwner(true);
								m_puntosCollidersLayers.RemoveAt(j);
								m_puedeHacerBindAnds.RemoveAt(j);
								puntos.RemoveAt(j);
								m_puntosMaxTimeToReachEmitor.RemoveAt(j);
								m_puntosStartPointsLocales.RemoveAt(j);
								m_puntosDefaultDrags.RemoveAt(j);
								semenPunto2.StartCheckDuration();
								semenPunto2.StartWaitToBind();
							}
							else
							{
								todosLosPuntosFueraDeEmisor = false;
								if (!emitionConfig.puedeHacerBindMientrasCorregeTrayectoria)
								{
									modificadorDeBool.valor.valor = false;
								}
								if (emitionConfig.ignorarCollisionesMientrasCorregeTrayectoria && semenPunto2.semenCollider != null)
								{
									semenPunto2.semenCollider.gameObject.layer = ConfiguracionGlobal.layersStatic.ignoreAll;
								}
								semenPunto2.DisableVisual(true);
								body.useGravity = false;
								body.drag = m_puntosDefaultDrags[j] + emitionConfig.corregiendTrayectoriaDragAdd;
								Vector3 vector3 = Math3d.ProjectPointOnLine(vector2, -vector, body.transform.position);
								body.transform.position = vector3;
								float num2 = Mathf.InverseLerp(0f, m_puntosMaxTimeToReachEmitor[j], num);
								Vector3 vector4 = Vector3.Lerp(emisor.TransformPoint(m_puntosStartPointsLocales[j]), vector2, num2);
								if (Vector3.Distance(vector2, vector4) < Vector3.Distance(vector2, vector3))
								{
									body.transform.position = vector4;
								}
								if (tieneInternals)
								{
									this.ProyectToInternals(holeInternals, body);
									semenPunto2.SendVisualToLayer(ConfiguracionGlobal.layersStatic.transparentFX);
								}
								if (num2 >= 1f)
								{
									modificadorDeBool.valor.valor = true;
									if (semenPunto2.semenCollider != null)
									{
										semenPunto2.semenCollider.gameObject.layer = m_puntosCollidersLayers[j];
									}
									semenPunto2.DisableVisual(false);
									body.useGravity = true;
									body.drag = m_puntosDefaultDrags[j];
									modificadorDeBool.TryRemoverDeOwner(true);
									m_puntosCollidersLayers.RemoveAt(j);
									m_puedeHacerBindAnds.RemoveAt(j);
									puntos.RemoveAt(j);
									m_puntosMaxTimeToReachEmitor.RemoveAt(j);
									m_puntosStartPointsLocales.RemoveAt(j);
									m_puntosDefaultDrags.RemoveAt(j);
									semenPunto2.StartCheckDuration();
									semenPunto2.StartWaitToBind();
								}
							}
						}
					}
				}
				if (!todosLosPuntosFueraDeEmisor)
				{
					yield return null;
				}
				if (todosLosPuntosFueraDeEmisor)
				{
					break;
				}
			}
			yield break;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00005C0E File Offset: 0x00003E0E
		[Obsolete("implementar corutina en after physcis constraint")]
		private IEnumerator CorregirPuntosRutine(SemenChain chain, Transform emisor, float maxDistance)
		{
			WaitForFixedUpdate w = new WaitForFixedUpdate();
			SemenPunto[] puntos = chain.semenPuntos.ToArray<SemenPunto>();
			yield return w;
			while (!(emisor == null))
			{
				bool todosLosPuntosFueraDeEmisor = true;
				Vector3 forward = emisor.forward;
				Vector3 position = emisor.position;
				foreach (SemenPunto semenPunto in puntos)
				{
					if (!(semenPunto == null))
					{
						Rigidbody body = semenPunto.body;
						if (!(body == null) && !body.isKinematic && Vector3.Dot(forward, (body.position - position).normalized) < 0f)
						{
							Vector3 vector = Math3d.ProjectPointOnLine(position, forward, body.position);
							if ((vector - body.position).sqrMagnitude < maxDistance * maxDistance)
							{
								todosLosPuntosFueraDeEmisor = false;
								body.position = vector;
							}
						}
					}
				}
				if (!todosLosPuntosFueraDeEmisor)
				{
					yield return w;
				}
				if (todosLosPuntosFueraDeEmisor)
				{
					break;
				}
			}
			yield break;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00005C2B File Offset: 0x00003E2B
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Emitir"
			};
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00005C44 File Offset: 0x00003E44
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.EmitirAnonimus();
		}

		// Token: 0x04000149 RID: 329
		public PuntoGenerico.Configuracion puntosConfig = new PuntoGenerico.Configuracion();

		// Token: 0x0400014A RID: 330
		public SemenPunto.Config semenPuntoConfig = new SemenPunto.Config();

		// Token: 0x0400014B RID: 331
		public EmisorDeSemenChain.NextEmisionConfig next = EmisorDeSemenChain.NextEmisionConfig.@default;

		// Token: 0x0400014C RID: 332
		public GameObject puntoPrefab;

		// Token: 0x0400014D RID: 333
		public TipoDeSemen tipo;

		// Token: 0x0400014F RID: 335
		private static List<Collider> m_TempPenisColliders = new List<Collider>();

		// Token: 0x02000155 RID: 341
		[Serializable]
		public struct NextEmisionConfig
		{
			// Token: 0x170004D3 RID: 1235
			// (get) Token: 0x06000DE0 RID: 3552 RVA: 0x0002FD70 File Offset: 0x0002DF70
			public static EmisorDeSemenChain.NextEmisionConfig @default
			{
				get
				{
					return new EmisorDeSemenChain.NextEmisionConfig
					{
						scale = 1f,
						maxVelocity = 3.75f,
						minVelocity = 2.5f,
						impulseOutPower = 0.33333334f,
						maxScale = 1f,
						minScale = 0.3333333f,
						scaleOutPower = 0.33333334f,
						maxWaitToBind = 0.01f,
						minWaitToBind = 0.01f,
						waitToBindOutPower = 1f,
						scaleRandomization = 1f,
						velocityRandomization = 0.25f,
						velocityDirectionRandomization = 0.2f,
						waitToBindRandomization = 0f,
						velocityDirectionRandomizationMinAngle = 0f,
						velocityDirectionRandomizationMaxAngle = 90f,
						distanceToBreakMod = 1f,
						count = 30,
						corregirTrayectoria = true,
						corregiendTrayectoriaDragAdd = 0f,
						puedeHacerBindMientrasCorregeTrayectoria = false,
						ignorarCollisionesMientrasCorregeTrayectoria = true
					};
				}
			}

			// Token: 0x040007F7 RID: 2039
			public float scale;

			// Token: 0x040007F8 RID: 2040
			public float maxVelocity;

			// Token: 0x040007F9 RID: 2041
			public float minVelocity;

			// Token: 0x040007FA RID: 2042
			public float impulseOutPower;

			// Token: 0x040007FB RID: 2043
			public float maxScale;

			// Token: 0x040007FC RID: 2044
			public float minScale;

			// Token: 0x040007FD RID: 2045
			public float scaleOutPower;

			// Token: 0x040007FE RID: 2046
			public float maxWaitToBind;

			// Token: 0x040007FF RID: 2047
			public float minWaitToBind;

			// Token: 0x04000800 RID: 2048
			public float waitToBindOutPower;

			// Token: 0x04000801 RID: 2049
			[Range(0f, 1f)]
			public float scaleRandomization;

			// Token: 0x04000802 RID: 2050
			[Range(0f, 1f)]
			public float velocityRandomization;

			// Token: 0x04000803 RID: 2051
			[Range(0f, 1f)]
			public float velocityDirectionRandomization;

			// Token: 0x04000804 RID: 2052
			[Range(0f, 1f)]
			public float waitToBindRandomization;

			// Token: 0x04000805 RID: 2053
			[Range(0f, 180f)]
			public float velocityDirectionRandomizationMinAngle;

			// Token: 0x04000806 RID: 2054
			[Range(0f, 180f)]
			public float velocityDirectionRandomizationMaxAngle;

			// Token: 0x04000807 RID: 2055
			public float distanceToBreakMod;

			// Token: 0x04000808 RID: 2056
			public int count;

			// Token: 0x04000809 RID: 2057
			public bool corregirTrayectoria;

			// Token: 0x0400080A RID: 2058
			public float corregiendTrayectoriaDragAdd;

			// Token: 0x0400080B RID: 2059
			public bool puedeHacerBindMientrasCorregeTrayectoria;

			// Token: 0x0400080C RID: 2060
			public bool ignorarCollisionesMientrasCorregeTrayectoria;
		}
	}
}
