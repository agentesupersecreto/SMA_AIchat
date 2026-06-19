using System;
using System.Collections.Generic;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000B3 RID: 179
	public class ParticleCore : MonoBehaviour, ILifeCore
	{
		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x060009DB RID: 2523 RVA: 0x00030EC4 File Offset: 0x0002F0C4
		// (set) Token: 0x060009DC RID: 2524 RVA: 0x00030ECC File Offset: 0x0002F0CC
		public GameObject Prefab
		{
			get
			{
				return this.mPrefab;
			}
			set
			{
				this.mPrefab = value;
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x060009DD RID: 2525 RVA: 0x00030ED5 File Offset: 0x0002F0D5
		// (set) Token: 0x060009DE RID: 2526 RVA: 0x00030EDD File Offset: 0x0002F0DD
		public Transform Transform
		{
			get
			{
				return this._Transform;
			}
			set
			{
				this._Transform = value;
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x060009DF RID: 2527 RVA: 0x00030EE6 File Offset: 0x0002F0E6
		// (set) Token: 0x060009E0 RID: 2528 RVA: 0x00030EEE File Offset: 0x0002F0EE
		public virtual float MaxAge
		{
			get
			{
				return this._MaxAge;
			}
			set
			{
				this._MaxAge = value;
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x060009E1 RID: 2529 RVA: 0x00030EF7 File Offset: 0x0002F0F7
		// (set) Token: 0x060009E2 RID: 2530 RVA: 0x00030EFF File Offset: 0x0002F0FF
		public virtual float Age
		{
			get
			{
				return this.mAge;
			}
			set
			{
				this.mAge = value;
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x060009E3 RID: 2531 RVA: 0x00030F08 File Offset: 0x0002F108
		// (set) Token: 0x060009E4 RID: 2532 RVA: 0x00030F10 File Offset: 0x0002F110
		public GameObject LifeRoot
		{
			get
			{
				return this._LifeRoot;
			}
			set
			{
				this._LifeRoot = value;
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x00030F19 File Offset: 0x0002F119
		// (set) Token: 0x060009E6 RID: 2534 RVA: 0x00030F24 File Offset: 0x0002F124
		public bool SkimSurface
		{
			get
			{
				return this._SkimSurface;
			}
			set
			{
				this._SkimSurface = value;
				if (this._SkimSurface && this.mParticleSystems != null && this.mParticleSystems.Length != 0 && this.mLifeParticlesArray == null)
				{
					this.mLifeParticlesArray = new List<ParticleSystem.Particle[]>();
					for (int i = 0; i < this.mParticleSystems.Length; i++)
					{
						this.mLifeParticlesArray.Add(new ParticleSystem.Particle[this.mParticleSystems[i].main.maxParticles]);
					}
				}
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x060009E7 RID: 2535 RVA: 0x00030F9C File Offset: 0x0002F19C
		// (set) Token: 0x060009E8 RID: 2536 RVA: 0x00030FA4 File Offset: 0x0002F1A4
		public float SkimSurfaceDistance
		{
			get
			{
				return this._SkimSurfaceDistance;
			}
			set
			{
				this._SkimSurfaceDistance = value;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x060009E9 RID: 2537 RVA: 0x00030FAD File Offset: 0x0002F1AD
		// (set) Token: 0x060009EA RID: 2538 RVA: 0x00030FB5 File Offset: 0x0002F1B5
		public int SkimSurfaceLayers
		{
			get
			{
				return this._SkimSurfaceLayers;
			}
			set
			{
				this._SkimSurfaceLayers = value;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x060009EB RID: 2539 RVA: 0x00030FBE File Offset: 0x0002F1BE
		// (set) Token: 0x060009EC RID: 2540 RVA: 0x00030FC8 File Offset: 0x0002F1C8
		public Transform Attractor
		{
			get
			{
				return this._Attractor;
			}
			set
			{
				this._Attractor = value;
				if (this._Attractor != null && this.mParticleSystems != null && this.mParticleSystems.Length != 0 && this.mLifeParticlesArray == null)
				{
					this.mLifeParticlesArray = new List<ParticleSystem.Particle[]>();
					for (int i = 0; i < this.mParticleSystems.Length; i++)
					{
						this.mLifeParticlesArray.Add(new ParticleSystem.Particle[this.mParticleSystems[i].main.maxParticles]);
					}
				}
			}
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x060009ED RID: 2541 RVA: 0x00031046 File Offset: 0x0002F246
		// (set) Token: 0x060009EE RID: 2542 RVA: 0x0003104E File Offset: 0x0002F24E
		public Vector3 AttractorOffset
		{
			get
			{
				return this._AttractorOffset;
			}
			set
			{
				this._AttractorOffset = value;
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x060009EF RID: 2543 RVA: 0x00031057 File Offset: 0x0002F257
		// (set) Token: 0x060009F0 RID: 2544 RVA: 0x0003105F File Offset: 0x0002F25F
		public float AudioFadeInSpeed
		{
			get
			{
				return this._AudioFadeInSpeed;
			}
			set
			{
				this._AudioFadeInSpeed = value;
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x00031068 File Offset: 0x0002F268
		// (set) Token: 0x060009F2 RID: 2546 RVA: 0x00031070 File Offset: 0x0002F270
		public float AudioFadeOutSpeed
		{
			get
			{
				return this._AudioFadeOutSpeed;
			}
			set
			{
				this._AudioFadeOutSpeed = value;
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x00031079 File Offset: 0x0002F279
		// (set) Token: 0x060009F4 RID: 2548 RVA: 0x00031081 File Offset: 0x0002F281
		public float LightFadeInSpeed
		{
			get
			{
				return this._LightFadeInSpeed;
			}
			set
			{
				this._LightFadeInSpeed = value;
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x060009F5 RID: 2549 RVA: 0x0003108A File Offset: 0x0002F28A
		// (set) Token: 0x060009F6 RID: 2550 RVA: 0x00031092 File Offset: 0x0002F292
		public float LightFadeOutSpeed
		{
			get
			{
				return this._LightFadeOutSpeed;
			}
			set
			{
				this._LightFadeOutSpeed = value;
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x060009F7 RID: 2551 RVA: 0x0003109B File Offset: 0x0002F29B
		// (set) Token: 0x060009F8 RID: 2552 RVA: 0x000310A3 File Offset: 0x0002F2A3
		public float ProjectorFadeInSpeed
		{
			get
			{
				return this._ProjectorFadeInSpeed;
			}
			set
			{
				this._ProjectorFadeInSpeed = value;
			}
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x060009F9 RID: 2553 RVA: 0x000310AC File Offset: 0x0002F2AC
		// (set) Token: 0x060009FA RID: 2554 RVA: 0x000310B4 File Offset: 0x0002F2B4
		public float ProjectorFadeOutSpeed
		{
			get
			{
				return this._ProjectorFadeOutSpeed;
			}
			set
			{
				this._ProjectorFadeOutSpeed = value;
			}
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x060009FB RID: 2555 RVA: 0x000310BD File Offset: 0x0002F2BD
		public GameObject LifeInstance
		{
			get
			{
				return this.mLifeInstance;
			}
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x000310C5 File Offset: 0x0002F2C5
		public virtual void Awake()
		{
			this._Transform = base.gameObject.transform;
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x000310D8 File Offset: 0x0002F2D8
		public virtual void Play()
		{
			this.mAge = 0f;
			this.mIsShuttingDown = false;
			if (this._LifeRoot != null)
			{
				Vector3 localScale = this._LifeRoot.transform.localScale;
				Quaternion rotation = this._LifeRoot.transform.rotation;
				Vector3 position = this._LifeRoot.transform.position;
				this.mLifeInstance = Object.Instantiate<GameObject>(this._LifeRoot);
				this.mLifeInstance.transform.parent = this._Transform;
				this.mLifeInstance.transform.localScale = localScale;
				this.mLifeInstance.transform.localRotation = rotation;
				this.mLifeInstance.transform.localPosition = position;
				if (this.mLifeInstance != null)
				{
					this.mParticleSystems = this.mLifeInstance.GetComponentsInChildren<ParticleSystem>();
					this.mProjectors = this.mLifeInstance.GetComponentsInChildren<Projector>();
					if (this.mProjectors != null && this._ProjectorFadeInSpeed > 0f)
					{
						if (this.mProjectorAlpha == null)
						{
							this.mProjectorAlpha = new Dictionary<Projector, float>();
						}
						this.mProjectorAlpha.Clear();
						for (int i = 0; i < this.mProjectors.Length; i++)
						{
							Material material = this.mProjectors[i].material;
							if (!material.name.EndsWith("(Clone)"))
							{
								material = new Material(material)
								{
									name = material.name + " (Clone)"
								};
								this.mProjectors[i].material = material;
							}
							for (int j = 0; j < ParticleCore.MATERIAL_COLORS.Length; j++)
							{
								if (material.HasProperty(ParticleCore.MATERIAL_COLORS[j]))
								{
									Color color = material.GetColor(ParticleCore.MATERIAL_COLORS[j]);
									this.mProjectorAlpha.Add(this.mProjectors[i], color.a);
									color.a = 0f;
									material.SetColor(ParticleCore.MATERIAL_COLORS[j], color);
									break;
								}
							}
						}
					}
				}
				if ((this._Attractor != null || this._SkimSurface) && this.mParticleSystems != null && this.mParticleSystems.Length != 0)
				{
					this.mLifeParticlesArray = new List<ParticleSystem.Particle[]>();
					for (int k = 0; k < this.mParticleSystems.Length; k++)
					{
						this.mLifeParticlesArray.Add(new ParticleSystem.Particle[this.mParticleSystems[k].main.maxParticles]);
					}
				}
				this.StartEffects(this.mLifeInstance);
			}
			if (this._Attractor != null)
			{
				Vector3 position2 = this._Transform.position;
				Vector3 normalized = (this._Attractor.position + this._Attractor.rotation * this._AttractorOffset - position2).normalized;
				this._Transform.rotation = Quaternion.LookRotation(normalized, Vector3.up);
			}
			if (this.mParticleSystems != null)
			{
				for (int l = 0; l < this.mParticleSystems.Length; l++)
				{
					if (this._Attractor != null && this.mLifeParticlesArray != null)
					{
						int particles = this.mParticleSystems[l].GetParticles(this.mLifeParticlesArray[l]);
						if (particles > 0 && this.mLifeParticlesArray != null)
						{
							for (int m = 0; m < particles; m++)
							{
								this.mLifeParticlesArray[l][m].position = Vector3.zero;
								this.mLifeParticlesArray[l][m].velocity = Vector3.zero;
							}
							this.mParticleSystems[l].SetParticles(this.mLifeParticlesArray[l], particles);
						}
					}
					this.mParticleSystems[l].Play(true);
				}
			}
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x000314A9 File Offset: 0x0002F6A9
		public virtual void Stop(bool rHardStop = false)
		{
			if (!this.mIsShuttingDown)
			{
				this.mIsShuttingDown = true;
				this.StopEffects(this.mLifeInstance);
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x000314C8 File Offset: 0x0002F6C8
		public virtual void Update()
		{
			this.mAge += Time.deltaTime;
			if (!this.mIsShuttingDown && this._MaxAge > 0f && this.mAge >= this._MaxAge)
			{
				this.Stop(false);
			}
			bool flag = this.UpdateEffects(this.mLifeInstance, this.mIsShuttingDown);
			if (this.mIsShuttingDown && !flag)
			{
				flag = this.UpdateEffects(this.mLifeInstance, this.mIsShuttingDown);
				this.Release();
			}
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00031548 File Offset: 0x0002F748
		public virtual void LateUpdate()
		{
			this.UpdateLifeParticles();
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x00031550 File Offset: 0x0002F750
		protected void StartEffects(GameObject rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			if (this.mParticleSystems != null)
			{
				for (int i = 0; i < this.mParticleSystems.Length; i++)
				{
					if (!this.mParticleSystems[i].IsAlive(true))
					{
						this.mParticleSystems[i].Play(true);
					}
				}
			}
			AudioSource[] componentsInChildren = rInstance.GetComponentsInChildren<AudioSource>();
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				if (!componentsInChildren[j].isPlaying && this.AudioFadeInSpeed <= 0f)
				{
					componentsInChildren[j].Play();
				}
			}
			Light[] componentsInChildren2 = rInstance.GetComponentsInChildren<Light>();
			for (int k = 0; k < componentsInChildren2.Length; k++)
			{
				if (componentsInChildren2[k].intensity == 0f && this.LightFadeInSpeed <= 0f)
				{
					componentsInChildren2[k].intensity = 1f;
				}
			}
			if (this.mProjectors != null)
			{
				for (int l = 0; l < this.mProjectors.Length; l++)
				{
					Material material = this.mProjectors[l].material;
					for (int m = 0; m < ParticleCore.MATERIAL_COLORS.Length; m++)
					{
						if (material.HasProperty(ParticleCore.MATERIAL_COLORS[m]))
						{
							Color color = material.GetColor(ParticleCore.MATERIAL_COLORS[m]);
							if (color.a == 0f && this.ProjectorFadeInSpeed <= 0f)
							{
								color.a = 1f;
								this.mProjectors[l].material.SetColor(ParticleCore.MATERIAL_COLORS[m], color);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x000316CC File Offset: 0x0002F8CC
		protected void StopEffects(GameObject rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			if (this.mParticleSystems != null)
			{
				for (int i = 0; i < this.mParticleSystems.Length; i++)
				{
					if (this.mParticleSystems[i].IsAlive(true))
					{
						this.mParticleSystems[i].Stop(true, ParticleSystemStopBehavior.StopEmitting);
					}
				}
			}
			AudioSource[] componentsInChildren = rInstance.GetComponentsInChildren<AudioSource>();
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				if (componentsInChildren[j].isPlaying && this.AudioFadeOutSpeed <= 0f)
				{
					componentsInChildren[j].Stop();
				}
			}
			Light[] componentsInChildren2 = rInstance.GetComponentsInChildren<Light>();
			for (int k = 0; k < componentsInChildren2.Length; k++)
			{
				if (componentsInChildren2[k].intensity > 0f && this.LightFadeOutSpeed <= 0f)
				{
					componentsInChildren2[k].intensity = 0f;
				}
			}
			if (this.mProjectors != null)
			{
				for (int l = 0; l < this.mProjectors.Length; l++)
				{
					Material material = this.mProjectors[l].material;
					for (int m = 0; m < ParticleCore.MATERIAL_COLORS.Length; m++)
					{
						if (material.HasProperty(ParticleCore.MATERIAL_COLORS[m]))
						{
							Color color = material.GetColor(ParticleCore.MATERIAL_COLORS[m]);
							if (color.a > 0f && this.ProjectorFadeOutSpeed <= 0f)
							{
								color.a = 0f;
								this.mProjectors[l].material.SetColor(ParticleCore.MATERIAL_COLORS[m], color);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x0003184C File Offset: 0x0002FA4C
		protected bool UpdateEffects(GameObject rInstance, bool rShutDown)
		{
			if (rInstance == null)
			{
				return false;
			}
			bool flag = false;
			if (!rShutDown)
			{
				if (this.mParticleSystems != null)
				{
					for (int i = 0; i < this.mParticleSystems.Length; i++)
					{
						if (this.mParticleSystems[i].IsAlive(true))
						{
							flag = true;
						}
					}
				}
				if (this.AudioFadeInSpeed > 0f)
				{
					AudioSource[] componentsInChildren = rInstance.GetComponentsInChildren<AudioSource>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						if (componentsInChildren[j].isPlaying)
						{
							flag = true;
							if (componentsInChildren[j].volume < 1f)
							{
								componentsInChildren[j].volume = Mathf.Clamp01(componentsInChildren[j].volume - this.AudioFadeInSpeed * Time.deltaTime);
							}
						}
					}
				}
				if (this.LightFadeInSpeed > 0f)
				{
					Light[] componentsInChildren2 = rInstance.GetComponentsInChildren<Light>();
					for (int k = 0; k < componentsInChildren2.Length; k++)
					{
						flag = true;
						if (componentsInChildren2[k].intensity < 1f)
						{
							componentsInChildren2[k].intensity = Mathf.Clamp01(componentsInChildren2[k].intensity + this.LightFadeInSpeed * Time.deltaTime);
						}
					}
				}
				if (this.mProjectors != null && this.ProjectorFadeInSpeed > 0f)
				{
					for (int l = 0; l < this.mProjectors.Length; l++)
					{
						float num = 1f;
						if (this.mProjectorAlpha.ContainsKey(this.mProjectors[l]))
						{
							num = this.mProjectorAlpha[this.mProjectors[l]];
						}
						Material material = this.mProjectors[l].material;
						for (int m = 0; m < ParticleCore.MATERIAL_COLORS.Length; m++)
						{
							if (material.HasProperty(ParticleCore.MATERIAL_COLORS[m]))
							{
								flag = true;
								Color color = material.GetColor(ParticleCore.MATERIAL_COLORS[m]);
								if (color.a < num)
								{
									color.a = Mathf.Clamp(color.a + this.ProjectorFadeInSpeed * Time.deltaTime, 0f, num);
									this.mProjectors[l].material.SetColor(ParticleCore.MATERIAL_COLORS[m], color);
								}
							}
						}
					}
				}
			}
			else
			{
				if (this.mParticleSystems != null)
				{
					for (int n = 0; n < this.mParticleSystems.Length; n++)
					{
						if (this.mParticleSystems[n].IsAlive(true))
						{
							flag = true;
						}
					}
				}
				AudioSource[] componentsInChildren3 = rInstance.GetComponentsInChildren<AudioSource>();
				for (int num2 = 0; num2 < componentsInChildren3.Length; num2++)
				{
					if (componentsInChildren3[num2].isPlaying && componentsInChildren3[num2].volume > 0f)
					{
						if (this.AudioFadeOutSpeed <= 0f)
						{
							componentsInChildren3[num2].volume = 0f;
						}
						else
						{
							componentsInChildren3[num2].volume = Mathf.Clamp01(componentsInChildren3[num2].volume - this.AudioFadeOutSpeed * Time.deltaTime);
						}
						if (componentsInChildren3[num2].volume > 0f)
						{
							flag = true;
						}
					}
				}
				Light[] componentsInChildren4 = rInstance.GetComponentsInChildren<Light>();
				for (int num3 = 0; num3 < componentsInChildren4.Length; num3++)
				{
					if (componentsInChildren4[num3].intensity > 0f)
					{
						if (this.LightFadeOutSpeed <= 0f)
						{
							componentsInChildren4[num3].intensity = 0f;
						}
						else
						{
							componentsInChildren4[num3].intensity = Mathf.Clamp01(componentsInChildren4[num3].intensity - this.LightFadeOutSpeed * Time.deltaTime);
						}
						if (componentsInChildren4[num3].intensity > 0f)
						{
							flag = true;
						}
					}
				}
				if (this.mProjectors != null)
				{
					for (int num4 = 0; num4 < this.mProjectors.Length; num4++)
					{
						Material material2 = this.mProjectors[num4].material;
						for (int num5 = 0; num5 < ParticleCore.MATERIAL_COLORS.Length; num5++)
						{
							if (material2.HasProperty(ParticleCore.MATERIAL_COLORS[num5]))
							{
								Color color2 = material2.GetColor(ParticleCore.MATERIAL_COLORS[num5]);
								if (color2.a > 0f)
								{
									if (this.ProjectorFadeOutSpeed <= 0f)
									{
										color2.a = 0f;
										this.mProjectors[num4].material.SetColor(ParticleCore.MATERIAL_COLORS[num5], color2);
									}
									else
									{
										color2.a = Mathf.Clamp01(color2.a - this.ProjectorFadeOutSpeed * Time.deltaTime);
										this.mProjectors[num4].material.SetColor(ParticleCore.MATERIAL_COLORS[num5], color2);
									}
									if (color2.a > 0f)
									{
										flag = true;
									}
								}
							}
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00031CBC File Offset: 0x0002FEBC
		protected virtual void UpdateLifeParticles()
		{
			if (this._Attractor != null)
			{
				Vector3 position = this._Transform.position;
				Vector3 vector = this._Attractor.position + this._Attractor.rotation * this._AttractorOffset;
				Vector3 vector2 = (vector - position).normalized;
				this._Transform.rotation = Quaternion.LookRotation(vector2, Vector3.up);
				vector = this._Transform.InverseTransformPoint(vector);
				vector2 = vector.normalized;
				if (this.mParticleSystems != null && this.mParticleSystems.Length != 0)
				{
					for (int i = 0; i < this.mParticleSystems.Length; i++)
					{
						if (this.mParticleSystems[i].IsAlive(true) && this._Attractor != null)
						{
							int particles = this.mParticleSystems[i].GetParticles(this.mLifeParticlesArray[i]);
							if (particles > 0 && this.mLifeParticlesArray != null)
							{
								for (int j = 0; j < particles; j++)
								{
									float num = this.mLifeParticlesArray[i][j].remainingLifetime / this.mLifeParticlesArray[i][j].startLifetime;
									this.mLifeParticlesArray[i][j].position = Vector3.Lerp(vector, Vector3.zero, num);
								}
								this.mParticleSystems[i].SetParticles(this.mLifeParticlesArray[i], particles);
							}
						}
					}
				}
			}
			if (this._SkimSurface)
			{
				float num2 = 5f;
				Vector3 up = this._Transform.up;
				Vector3 vector3 = -up;
				Vector3 vector4 = up * 1f;
				Vector3 vector5 = up * this._SkimSurfaceDistance;
				if (this.mParticleSystems != null && this.mParticleSystems.Length != 0)
				{
					for (int k = 0; k < this.mParticleSystems.Length; k++)
					{
						if (this.mParticleSystems[k].IsAlive(true))
						{
							bool flag = this.mParticleSystems[k].main.simulationSpace == ParticleSystemSimulationSpace.Local;
							int particles2 = this.mParticleSystems[k].GetParticles(this.mLifeParticlesArray[k]);
							if (particles2 > 0 && this.mLifeParticlesArray != null)
							{
								for (int l = 0; l < particles2; l++)
								{
									Vector3 vector6 = this.mLifeParticlesArray[k][l].position;
									if (flag)
									{
										vector6 = this._LifeRoot.transform.TransformPoint(vector6);
									}
									vector6 += vector4;
									RaycastHit raycastHit;
									if (Physics.Raycast(vector6, vector3, out raycastHit, num2, this._SkimSurfaceLayers, QueryTriggerInteraction.Ignore))
									{
										Vector3 vector7 = raycastHit.point + vector5;
										if (flag)
										{
											vector7 = this._LifeRoot.transform.InverseTransformPoint(vector7);
										}
										this.mLifeParticlesArray[k][l].position = vector7;
										Quaternion quaternion = Quaternion.FromToRotation(raycastHit.normal, Vector3.forward) * this._LifeRoot.transform.rotation;
										this.mLifeParticlesArray[k][l].axisOfRotation = quaternion.Forward();
										this.mLifeParticlesArray[k][l].rotation3D = quaternion.eulerAngles;
									}
								}
								this.mParticleSystems[k].SetParticles(this.mLifeParticlesArray[k], particles2);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x0003206C File Offset: 0x0003026C
		public virtual void Release()
		{
			if (this.OnReleasedEvent != null)
			{
				this.OnReleasedEvent(this, null);
			}
			if (this.mLifeInstance != null)
			{
				Object.Destroy(this.mLifeInstance);
			}
			Object.Destroy(base.gameObject);
			this.mAge = 0f;
			this.mIsShuttingDown = false;
			this.OnReleasedEvent = null;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00032180 File Offset: 0x00030380
		GameObject ILifeCore.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x040004D7 RID: 1239
		public const float EPSILON = 0.001f;

		// Token: 0x040004D8 RID: 1240
		private static string[] MATERIAL_COLORS = new string[] { "_Color", "_MainColor", "_TintColor", "_EmissionColor", "_BorderColor", "_ReflectColor", "_RimColor", "_CoreColor" };

		// Token: 0x040004D9 RID: 1241
		protected GameObject mPrefab;

		// Token: 0x040004DA RID: 1242
		[NonSerialized]
		public Transform _Transform;

		// Token: 0x040004DB RID: 1243
		public float _MaxAge = 1f;

		// Token: 0x040004DC RID: 1244
		protected float mAge;

		// Token: 0x040004DD RID: 1245
		public GameObject _LifeRoot;

		// Token: 0x040004DE RID: 1246
		public bool _SkimSurface;

		// Token: 0x040004DF RID: 1247
		public float _SkimSurfaceDistance = 0.05f;

		// Token: 0x040004E0 RID: 1248
		public int _SkimSurfaceLayers = -1;

		// Token: 0x040004E1 RID: 1249
		public Transform _Attractor;

		// Token: 0x040004E2 RID: 1250
		public Vector3 _AttractorOffset = Vector3.zero;

		// Token: 0x040004E3 RID: 1251
		public float _AudioFadeInSpeed;

		// Token: 0x040004E4 RID: 1252
		public float _AudioFadeOutSpeed = 1f;

		// Token: 0x040004E5 RID: 1253
		public float _LightFadeInSpeed;

		// Token: 0x040004E6 RID: 1254
		public float _LightFadeOutSpeed = 1f;

		// Token: 0x040004E7 RID: 1255
		public float _ProjectorFadeInSpeed;

		// Token: 0x040004E8 RID: 1256
		public float _ProjectorFadeOutSpeed = 1f;

		// Token: 0x040004E9 RID: 1257
		[NonSerialized]
		public LifeCoreDelegate OnReleasedEvent;

		// Token: 0x040004EA RID: 1258
		protected GameObject mLifeInstance;

		// Token: 0x040004EB RID: 1259
		protected ParticleSystem[] mParticleSystems;

		// Token: 0x040004EC RID: 1260
		protected List<ParticleSystem.Particle[]> mLifeParticlesArray;

		// Token: 0x040004ED RID: 1261
		protected Projector[] mProjectors;

		// Token: 0x040004EE RID: 1262
		protected Dictionary<Projector, float> mProjectorAlpha;

		// Token: 0x040004EF RID: 1263
		protected bool mIsShuttingDown;
	}
}
