using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000C6 RID: 198
	public abstract class Character : AplicableBehaviour, ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable, ICharacterIdentificable, ICharacterUnico, ICharacterGuardableToMemory
	{
		// Token: 0x1700025B RID: 603
		// (get) Token: 0x0600061E RID: 1566 RVA: 0x00013287 File Offset: 0x00011487
		ICharacter ICharacterTeleportable.self
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x0001328A File Offset: 0x0001148A
		public string ID_UnicoString
		{
			get
			{
				return this.m_ID_UnicoString;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000620 RID: 1568 RVA: 0x00013292 File Offset: 0x00011492
		public Guid ID_Unico
		{
			get
			{
				return this.m_ID_Unico;
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000621 RID: 1569 RVA: 0x0001329A File Offset: 0x0001149A
		public string nombreCompleto
		{
			get
			{
				return this.m_nombreCompleto;
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000622 RID: 1570 RVA: 0x000132A2 File Offset: 0x000114A2
		public string nombre
		{
			get
			{
				return this.m_Nombre;
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x000132AA File Offset: 0x000114AA
		public string apellido
		{
			get
			{
				return this.m_Apellido;
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000624 RID: 1572 RVA: 0x000132B2 File Offset: 0x000114B2
		public virtual Sexo sexo
		{
			get
			{
				return Sexo.noDefinido;
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000625 RID: 1573 RVA: 0x000132B5 File Offset: 0x000114B5
		public bool isBinded
		{
			get
			{
				return this.m_isBinded;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000626 RID: 1574 RVA: 0x000132BD File Offset: 0x000114BD
		public Quaternion armatureOrientationOffSet
		{
			get
			{
				return this.m_armatureOrientationOffSet;
			}
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x000132C5 File Offset: 0x000114C5
		public virtual void Bind(string nuevoNombreCompleto, string nuevoNombre, string nuevoApellido, Guid nuevoID, object extradata)
		{
			this.Bind(nuevoNombreCompleto, nuevoNombre, nuevoApellido, nuevoID);
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x000132D4 File Offset: 0x000114D4
		public virtual void Bind(string nuevoNombreCompleto, string nuevoNombre, string nuevoApellido, Guid nuevoID)
		{
			if (this.isBinded)
			{
				throw new InvalidOperationException();
			}
			if (Singleton<CharacteresActivos>.IsInScene)
			{
				Singleton<CharacteresActivos>.instance.Unregistrar(this);
			}
			if (Singleton<CharacteresExistentesEnScena>.IsInScene)
			{
				Singleton<CharacteresExistentesEnScena>.instance.Unregistrar(this);
			}
			this.m_ID_Unico = nuevoID;
			this.m_ID_UnicoString = this.m_ID_Unico.ToString();
			if (this.bodyAnimator != null)
			{
				this.bodyAnimator.name = nuevoNombreCompleto;
			}
			this.m_nombreCompleto = nuevoNombreCompleto;
			this.m_Nombre = nuevoNombre;
			this.m_Apellido = nuevoApellido;
			if (base.isActiveAndEnabled && base.isStared && !this.m_noRegistrar)
			{
				if (Singleton<CharacteresActivos>.IsInScene)
				{
					Singleton<CharacteresActivos>.instance.Registrar(this);
				}
				if (Singleton<CharacteresExistentesEnScena>.IsInScene)
				{
					Singleton<CharacteresExistentesEnScena>.instance.Registrar(this);
				}
			}
			this.m_isBinded = true;
			if (this.apareienciaFisicaLoaded && !this.memoryApareienciaFisicaLoaded)
			{
				this.LoadMemoriaApareienciaFisica();
			}
			if (this.isAILoaded && !this.isMemoryLoaded)
			{
				this.LoadMemoria();
			}
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x000133D0 File Offset: 0x000115D0
		public void UpdateName(string nuevoNombreCompleto, string nuevoNombre, string nuevoApellido)
		{
			if (!this.isBinded)
			{
				throw new InvalidOperationException();
			}
			if (this.bodyAnimator != null)
			{
				this.bodyAnimator.name = nuevoNombreCompleto;
			}
			this.m_nombreCompleto = nuevoNombreCompleto;
			this.m_Nombre = nuevoNombre;
			this.m_Apellido = nuevoApellido;
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0001340F File Offset: 0x0001160F
		private void OnEnableStateChanged()
		{
			if (!Singleton<CharacteresActivos>.IsInScene)
			{
				return;
			}
			Singleton<CharacteresActivos>.instance.Unregistrar(this);
			if (base.isActiveAndEnabled && this.isBinded && !this.m_noRegistrar)
			{
				Singleton<CharacteresActivos>.instance.Registrar(this);
			}
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x00013447 File Offset: 0x00011647
		private void OnExistStateChanged()
		{
			if (!Singleton<CharacteresExistentesEnScena>.IsInScene)
			{
				return;
			}
			Singleton<CharacteresExistentesEnScena>.instance.Unregistrar(this);
			if (!base.isDestroyed && !base.isDestroying && this.isBinded && !this.m_noRegistrar)
			{
				Singleton<CharacteresExistentesEnScena>.instance.Registrar(this);
			}
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00013488 File Offset: 0x00011688
		protected void SoftBind()
		{
			if (Singleton<CharacteresActivos>.IsInScene)
			{
				Singleton<CharacteresActivos>.instance.Unregistrar(this);
			}
			if (Singleton<CharacteresExistentesEnScena>.IsInScene)
			{
				Singleton<CharacteresExistentesEnScena>.instance.Unregistrar(this);
			}
			Guid guid = Guid.NewGuid();
			string text = guid.ToString();
			this.m_ID_Unico = guid;
			if (Application.isEditor)
			{
				this.m_ID_UnicoString = this.m_ID_Unico.ToString();
			}
			if (this.bodyAnimator != null)
			{
				this.bodyAnimator.name = text;
			}
			this.m_nombreCompleto = text;
			if (base.isActiveAndEnabled && base.isStared && !this.m_noRegistrar && !this.m_noRegistrar)
			{
				if (Singleton<CharacteresActivos>.IsInScene)
				{
					Singleton<CharacteresActivos>.instance.Registrar(this);
				}
				if (Singleton<CharacteresExistentesEnScena>.IsInScene)
				{
					Singleton<CharacteresExistentesEnScena>.instance.Registrar(this);
				}
			}
		}

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x0600062D RID: 1581 RVA: 0x00013558 File Offset: 0x00011758
		// (remove) Token: 0x0600062E RID: 1582 RVA: 0x00013590 File Offset: 0x00011790
		public event Character.MovingHandler teleporting;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x0600062F RID: 1583 RVA: 0x000135C8 File Offset: 0x000117C8
		// (remove) Token: 0x06000630 RID: 1584 RVA: 0x00013600 File Offset: 0x00011800
		public event Character.MovedHandler teleported;

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000631 RID: 1585
		public abstract bool isAlive { get; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x00013635 File Offset: 0x00011835
		public Transform hips
		{
			get
			{
				return this.bodyAnimator.GetBoneTransform(HumanBodyBones.Hips);
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000633 RID: 1587
		public abstract Vector3 boneForward { get; }

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000634 RID: 1588
		public abstract Vector3 boneUp { get; }

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000635 RID: 1589
		public abstract Vector3 worldHeadPosition { get; }

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000636 RID: 1590
		public abstract Vector3 centerOfMassVelocity { get; }

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000637 RID: 1591
		public abstract Quaternion centerOfMassRotation { get; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000638 RID: 1592
		public abstract Vector3 centerOfMassPosition { get; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000639 RID: 1593
		public abstract Vector3 centerOfMassUpDirection { get; }

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x0600063A RID: 1594
		public abstract Vector3 centerOfMassForwardDirection { get; }

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x0600063B RID: 1595
		public abstract Vector3 centerOfMassRightDirection { get; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x0600063C RID: 1596
		public abstract Vector3 worldFirstPersonViewPoint { get; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x0600063D RID: 1597
		public abstract Vector3 worldViewDirection { get; }

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x0600063E RID: 1598
		public abstract Vector3 localFPSOffset { get; }

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x0600063F RID: 1599
		public abstract Vector3 localEarFormHeadR { get; }

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000640 RID: 1600
		public abstract Vector3 localEarFormHeadL { get; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000641 RID: 1601
		public abstract Vector3 worldHeadUp { get; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000642 RID: 1602
		public abstract float altura { get; }

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000643 RID: 1603
		public abstract float escala { get; }

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000644 RID: 1604
		public abstract float defaultEstatura { get; }

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000645 RID: 1605
		public abstract float defaultHandWidth { get; }

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000646 RID: 1606
		public abstract float defaultHandHeight { get; }

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x00013643 File Offset: 0x00011843
		public float estatura
		{
			get
			{
				return this.altura;
			}
		}

		// Token: 0x06000648 RID: 1608
		public abstract Rigidbody TryObtenerPartePhysica(HumanBodyBones boneEnum);

		// Token: 0x06000649 RID: 1609
		public abstract Rigidbody TryObtenerPartePhysica(Transform characterBone);

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x0600064A RID: 1610
		public abstract Transform trasnformParaObservar { get; }

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x0600064B RID: 1611
		public abstract Transform trasnformParaManipular { get; }

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x0600064C RID: 1612
		public abstract Transform trasnformParaComunicarse { get; }

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x0600064D RID: 1613
		public abstract Transform animatorRootMotionTransform { get; }

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x0600064E RID: 1614
		public abstract Animator bodyAnimator { get; }

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x0600064F RID: 1615
		public abstract Animator headAnimator { get; }

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000650 RID: 1616
		public abstract Transform rootBoneTransform { get; }

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x0001364B File Offset: 0x0001184B
		public Transform cameraAtadaTransform
		{
			get
			{
				if (!this.m_camera)
				{
					return null;
				}
				return this.m_camera.transform;
			}
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x00013667 File Offset: 0x00011867
		public CamaraAtable cameraAtada
		{
			get
			{
				return this.m_camera;
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000653 RID: 1619
		public abstract Vector3 posicion { get; }

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000654 RID: 1620
		public abstract Quaternion rotacion { get; }

		// Token: 0x06000655 RID: 1621 RVA: 0x0001366F File Offset: 0x0001186F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.internalAfterStared += this.Character_internalAfterStared;
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x00013689 File Offset: 0x00011889
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.OnEnableStateChanged();
			}
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x000136A0 File Offset: 0x000118A0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.boneForward == Vector3.zero)
			{
				throw new InvalidOperationException();
			}
			if (this.boneUp == Vector3.zero)
			{
				throw new InvalidOperationException();
			}
			if (!ExtendedMonoBehaviour.AlmostEqual(Vector3.Dot(this.boneForward, this.boneUp), 0f, 0.001f))
			{
				throw new InvalidOperationException();
			}
			this.m_armatureOrientationOffSet = Quaternion.Inverse(Quaternion.identity) * Quaternion.LookRotation(this.boneForward, this.boneUp);
			this.OnEnableStateChanged();
			this.OnExistStateChanged();
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x00013740 File Offset: 0x00011940
		private void Character_internalAfterStared()
		{
			if (!this.isBinded)
			{
				this.SoftBind();
				Debug.Log("Character " + base.name + " was auto Soft-Binded...", this);
			}
			this.LoadApareienciaFisica();
			if (this.isBinded)
			{
				this.LoadMemoriaApareienciaFisica();
			}
			this.LoadAI();
			if (this.isBinded)
			{
				this.LoadMemoria();
			}
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0001379E File Offset: 0x0001199E
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.OnEnableStateChanged();
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x000137AD File Offset: 0x000119AD
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.OnExistStateChanged();
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x000137BC File Offset: 0x000119BC
		public void SetPositionAndRotation(Transform targetTransform)
		{
			if (targetTransform == null)
			{
				throw new ArgumentNullException("targetTransform", "targetTransform null reference.");
			}
			this.SetPositionAndRotation(targetTransform.position, targetTransform.rotation);
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x000137EC File Offset: 0x000119EC
		public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
		{
			Transform animatorRootMotionTransform = this.animatorRootMotionTransform;
			this.OnChangingPositionAndRotation(ref position, ref rotation);
			Character.MovingHandler movingHandler = this.teleporting;
			if (movingHandler != null)
			{
				movingHandler(ref position, ref rotation);
			}
			animatorRootMotionTransform.SetPositionAndRotation(position, rotation);
			this.OnChangedPositionAndRotation(position, rotation);
			Character.MovedHandler movedHandler = this.teleported;
			if (movedHandler == null)
			{
				return;
			}
			movedHandler(position, rotation);
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0001383F File Offset: 0x00011A3F
		protected virtual void OnChangingPositionAndRotation(ref Vector3 posicion, ref Quaternion rotacion)
		{
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x00013841 File Offset: 0x00011A41
		protected virtual void OnChangedPositionAndRotation(Vector3 posicion, Quaternion rotacion)
		{
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x0600065F RID: 1631 RVA: 0x00013843 File Offset: 0x00011A43
		public bool apareienciaFisicaLoaded
		{
			get
			{
				return this.m_apareienciaFisicaLoaded;
			}
		}

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06000660 RID: 1632 RVA: 0x0001384C File Offset: 0x00011A4C
		// (remove) Token: 0x06000661 RID: 1633 RVA: 0x00013884 File Offset: 0x00011A84
		public event Action<ICharacter> loadingApareienciaFisica;

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000662 RID: 1634 RVA: 0x000138BC File Offset: 0x00011ABC
		// (remove) Token: 0x06000663 RID: 1635 RVA: 0x000138F4 File Offset: 0x00011AF4
		public event Action<ICharacter> onLoadApareienciaFisica;

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000664 RID: 1636 RVA: 0x0001392C File Offset: 0x00011B2C
		// (remove) Token: 0x06000665 RID: 1637 RVA: 0x00013964 File Offset: 0x00011B64
		public event Action<ICharacter> loadedApareienciaFisica;

		// Token: 0x06000666 RID: 1638 RVA: 0x0001399C File Offset: 0x00011B9C
		protected virtual void LoadApareienciaFisica()
		{
			Action<ICharacter> action = this.loadingApareienciaFisica;
			if (action != null)
			{
				action(this);
			}
			Action<ICharacter> action2 = this.onLoadApareienciaFisica;
			if (action2 != null)
			{
				action2(this);
			}
			this.m_apareienciaFisicaLoaded = true;
			Action<ICharacter> action3 = this.loadedApareienciaFisica;
			if (action3 != null)
			{
				action3(this);
			}
			this.loadingApareienciaFisica = null;
			this.onLoadApareienciaFisica = null;
			this.loadedApareienciaFisica = null;
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x000139FB File Offset: 0x00011BFB
		public bool memoryApareienciaFisicaLoaded
		{
			get
			{
				return this.m_memoryApareienciaFisicaLoaded;
			}
		}

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000668 RID: 1640 RVA: 0x00013A04 File Offset: 0x00011C04
		// (remove) Token: 0x06000669 RID: 1641 RVA: 0x00013A3C File Offset: 0x00011C3C
		public event Action<ICharacter> memoryLoadingApareienciaFisica;

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x0600066A RID: 1642 RVA: 0x00013A74 File Offset: 0x00011C74
		// (remove) Token: 0x0600066B RID: 1643 RVA: 0x00013AAC File Offset: 0x00011CAC
		public event Action<ICharacter> memoryOnLoadApareienciaFisica;

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x0600066C RID: 1644 RVA: 0x00013AE4 File Offset: 0x00011CE4
		// (remove) Token: 0x0600066D RID: 1645 RVA: 0x00013B1C File Offset: 0x00011D1C
		public event Action<ICharacter> memoryLoadedApareienciaFisica;

		// Token: 0x0600066E RID: 1646 RVA: 0x00013B54 File Offset: 0x00011D54
		protected virtual void LoadMemoriaApareienciaFisica()
		{
			Action<ICharacter> action = this.memoryLoadingApareienciaFisica;
			if (action != null)
			{
				action(this);
			}
			Action<ICharacter> action2 = this.memoryOnLoadApareienciaFisica;
			if (action2 != null)
			{
				action2(this);
			}
			this.m_memoryApareienciaFisicaLoaded = true;
			Action<ICharacter> action3 = this.memoryLoadedApareienciaFisica;
			if (action3 != null)
			{
				action3(this);
			}
			this.memoryLoadingApareienciaFisica = null;
			this.memoryOnLoadApareienciaFisica = null;
			this.memoryLoadedApareienciaFisica = null;
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x0600066F RID: 1647
		public abstract ICharacter master { get; }

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x00013BB3 File Offset: 0x00011DB3
		public bool isAILoaded
		{
			get
			{
				return this.m_AILoaded;
			}
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06000671 RID: 1649 RVA: 0x00013BBC File Offset: 0x00011DBC
		// (remove) Token: 0x06000672 RID: 1650 RVA: 0x00013BF4 File Offset: 0x00011DF4
		public event Action<Character> loadingAI;

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06000673 RID: 1651 RVA: 0x00013C2C File Offset: 0x00011E2C
		// (remove) Token: 0x06000674 RID: 1652 RVA: 0x00013C64 File Offset: 0x00011E64
		public event Action<Character> onLoadAI;

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06000675 RID: 1653 RVA: 0x00013C9C File Offset: 0x00011E9C
		// (remove) Token: 0x06000676 RID: 1654 RVA: 0x00013CD4 File Offset: 0x00011ED4
		public event Action<Character> loadedAI;

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x00013D09 File Offset: 0x00011F09
		public ModificableDeBool isLoadedAND
		{
			get
			{
				return this.m_isLoadedAND;
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x00013D11 File Offset: 0x00011F11
		public bool loaded
		{
			get
			{
				return this.apareienciaFisicaLoaded && this.memoryApareienciaFisicaLoaded && this.isAILoaded && this.isMemoryLoaded && this.m_isLoadedAND.And(base.isActiveAndEnabled);
			}
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x00013D48 File Offset: 0x00011F48
		protected virtual void LoadAI()
		{
			Action<Character> action = this.loadingAI;
			if (action != null)
			{
				action(this);
			}
			Action<Character> action2 = this.onLoadAI;
			if (action2 != null)
			{
				action2(this);
			}
			this.m_AILoaded = true;
			Action<Character> action3 = this.loadedAI;
			if (action3 != null)
			{
				action3(this);
			}
			this.loadingAI = null;
			this.onLoadAI = null;
			this.loadedAI = null;
		}

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x0600067A RID: 1658 RVA: 0x00013DA8 File Offset: 0x00011FA8
		// (remove) Token: 0x0600067B RID: 1659 RVA: 0x00013DE0 File Offset: 0x00011FE0
		public event ICharacterGuardableToMemory.SaveHandler memorySaving;

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x0600067C RID: 1660 RVA: 0x00013E18 File Offset: 0x00012018
		// (remove) Token: 0x0600067D RID: 1661 RVA: 0x00013E50 File Offset: 0x00012050
		public event ICharacterGuardableToMemory.SaveHandler memoryOnSave;

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x0600067E RID: 1662 RVA: 0x00013E88 File Offset: 0x00012088
		// (remove) Token: 0x0600067F RID: 1663 RVA: 0x00013EC0 File Offset: 0x000120C0
		public event ICharacterGuardableToMemory.SaveHandler memorySaved;

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06000680 RID: 1664 RVA: 0x00013EF8 File Offset: 0x000120F8
		// (remove) Token: 0x06000681 RID: 1665 RVA: 0x00013F30 File Offset: 0x00012130
		public event ICharacterGuardableToMemory.LoadHandler memoryLoading;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x06000682 RID: 1666 RVA: 0x00013F68 File Offset: 0x00012168
		// (remove) Token: 0x06000683 RID: 1667 RVA: 0x00013FA0 File Offset: 0x000121A0
		public event ICharacterGuardableToMemory.LoadHandler memoryOnLoad;

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x06000684 RID: 1668 RVA: 0x00013FD8 File Offset: 0x000121D8
		// (remove) Token: 0x06000685 RID: 1669 RVA: 0x00014010 File Offset: 0x00012210
		public event ICharacterGuardableToMemory.LoadHandler memoryLoaded;

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000686 RID: 1670 RVA: 0x00014045 File Offset: 0x00012245
		public bool isMemoryLoaded
		{
			get
			{
				return this.m_isMemoryLoaded;
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x0001404D File Offset: 0x0001224D
		public bool doSaveOnlyWhenActive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000688 RID: 1672 RVA: 0x00014050 File Offset: 0x00012250
		public bool doLoadOnlyWhenActive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x06000689 RID: 1673 RVA: 0x00014054 File Offset: 0x00012254
		// (remove) Token: 0x0600068A RID: 1674 RVA: 0x0001408C File Offset: 0x0001228C
		public event Action<Character> charMemoryLoading;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x0600068B RID: 1675 RVA: 0x000140C4 File Offset: 0x000122C4
		// (remove) Token: 0x0600068C RID: 1676 RVA: 0x000140FC File Offset: 0x000122FC
		public event Action<Character> charMemoryOnLoad;

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x0600068D RID: 1677 RVA: 0x00014134 File Offset: 0x00012334
		// (remove) Token: 0x0600068E RID: 1678 RVA: 0x0001416C File Offset: 0x0001236C
		public event Action<Character> charMemoryJustLoaded;

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x0600068F RID: 1679 RVA: 0x000141A4 File Offset: 0x000123A4
		// (remove) Token: 0x06000690 RID: 1680 RVA: 0x000141DC File Offset: 0x000123DC
		public event Action<Character> charMemoryLoaded;

		// Token: 0x06000691 RID: 1681 RVA: 0x00014214 File Offset: 0x00012414
		protected virtual void LoadMemoria()
		{
			Action<Character> action = this.charMemoryLoading;
			if (action != null)
			{
				action(this);
			}
			Action<Character> action2 = this.charMemoryOnLoad;
			if (action2 != null)
			{
				action2(this);
			}
			this.m_isMemoryLoaded = true;
			Action<Character> action3 = this.charMemoryJustLoaded;
			if (action3 != null)
			{
				action3(this);
			}
			Action<Character> action4 = this.charMemoryLoaded;
			if (action4 != null)
			{
				action4(this);
			}
			this.charMemoryLoading = null;
			this.charMemoryOnLoad = null;
			this.charMemoryJustLoaded = null;
			this.charMemoryLoaded = null;
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0001428C File Offset: 0x0001248C
		void ICharacterGuardableToMemory.DoLoadFromMemory(object fromMemory)
		{
			ICharacterGuardableToMemory.LoadHandler loadHandler = this.memoryLoading;
			if (loadHandler != null)
			{
				loadHandler(fromMemory, this);
			}
			ICharacterGuardableToMemory.LoadHandler loadHandler2 = this.memoryOnLoad;
			if (loadHandler2 != null)
			{
				loadHandler2(fromMemory, this);
			}
			ICharacterGuardableToMemory.LoadHandler loadHandler3 = this.memoryLoaded;
			if (loadHandler3 == null)
			{
				return;
			}
			loadHandler3(fromMemory, this);
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x000142C6 File Offset: 0x000124C6
		void ICharacterGuardableToMemory.DoSaveToMemory(object toMemory)
		{
			ICharacterGuardableToMemory.SaveHandler saveHandler = this.memorySaving;
			if (saveHandler != null)
			{
				saveHandler(toMemory, this);
			}
			ICharacterGuardableToMemory.SaveHandler saveHandler2 = this.memoryOnSave;
			if (saveHandler2 != null)
			{
				saveHandler2(toMemory, this);
			}
			ICharacterGuardableToMemory.SaveHandler saveHandler3 = this.memorySaved;
			if (saveHandler3 == null)
			{
				return;
			}
			saveHandler3(toMemory, this);
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00014300 File Offset: 0x00012500
		protected sealed override CustomMonobehaviourBotonConfig Boton2()
		{
			if (this.flagMoveTo == null)
			{
				return null;
			}
			return new CustomMonobehaviourBotonConfig
			{
				confirmar = true,
				editorTimeVisible = false,
				text = "Mover A transform"
			};
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00014330 File Offset: 0x00012530
		protected sealed override void OnAplicar2()
		{
			base.OnAplicar2();
			this.SetPositionAndRotation(this.flagMoveTo);
			this.flagMoveTo = null;
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0001434B File Offset: 0x0001254B
		[Obsolete("usar la extencion")]
		public ParteQuePuedeEstimular ParteDeObjeto(Transform obj)
		{
			return this.ParteQuePuedeEstimularDeTransform(obj);
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x00014354 File Offset: 0x00012554
		public virtual bool ObjetoEsProp(Transform obj)
		{
			return false;
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x00014357 File Offset: 0x00012557
		public virtual bool ObjetoMePertenece(Transform obj)
		{
			return obj.IsChildOf(base.transform);
		}

		// Token: 0x06000699 RID: 1689
		public abstract bool ObjetoEsMiPierna(Collider obj);

		// Token: 0x0600069A RID: 1690
		public abstract bool ObjetoEsMiPierna(Rigidbody obj);

		// Token: 0x0600069B RID: 1691
		public abstract bool ObjetoEsMiPierna(Transform obj);

		// Token: 0x0600069C RID: 1692
		public abstract bool ObjetoEsMiTorzo(Collider obj);

		// Token: 0x0600069D RID: 1693
		public abstract bool ObjetoEsMiTorzo(Rigidbody obj);

		// Token: 0x0600069E RID: 1694
		public abstract bool ObjetoEsMiTorzo(Transform obj);

		// Token: 0x0600069F RID: 1695
		public abstract bool ObjetoEsMiPene(Collider obj);

		// Token: 0x060006A0 RID: 1696
		public abstract bool ObjetoEsMiPene(Rigidbody obj);

		// Token: 0x060006A1 RID: 1697
		public abstract bool ObjetoEsMiPene(Transform obj);

		// Token: 0x060006A2 RID: 1698
		public abstract bool ObjetoEsMiPene(Component obj);

		// Token: 0x060006A3 RID: 1699
		public abstract bool ObjetoEsMiMano(Collider obj);

		// Token: 0x060006A4 RID: 1700
		public abstract bool ObjetoEsMiMano(Rigidbody obj);

		// Token: 0x060006A5 RID: 1701
		public abstract bool ObjetoEsMiMano(Transform obj);

		// Token: 0x060006A6 RID: 1702
		public abstract bool ObjetoEsMiAnteBrazo(Transform obj);

		// Token: 0x060006A7 RID: 1703
		public abstract bool ObjetoEsMiDedo(Collider obj);

		// Token: 0x060006A8 RID: 1704
		public abstract bool ObjetoEsMiDedo(Rigidbody obj);

		// Token: 0x060006A9 RID: 1705
		public abstract bool ObjetoEsMiDedo(Transform obj);

		// Token: 0x060006AA RID: 1706
		public abstract bool ObjetoEsMiDedo(Component obj);

		// Token: 0x060006AB RID: 1707 RVA: 0x00014368 File Offset: 0x00012568
		public void IgnorarCollosionesConManos(IReadOnlyList<Collider> others, bool ignore)
		{
			for (int i = 0; i < others.Count; i++)
			{
				this.IgnorarCollosionesConManos(others[i], ignore);
			}
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00014394 File Offset: 0x00012594
		public void IgnorarCollosionesConManos(IList<Collider> others, bool ignore)
		{
			for (int i = 0; i < others.Count; i++)
			{
				this.IgnorarCollosionesConManos(others[i], ignore);
			}
		}

		// Token: 0x060006AD RID: 1709
		public abstract void IgnorarCollosionesConManos(Collider other, bool ignore);

		// Token: 0x060006AE RID: 1710 RVA: 0x000143C0 File Offset: 0x000125C0
		public void IgnorarCollosionesConMano(IReadOnlyList<Collider> others, Side side, bool ignore)
		{
			for (int i = 0; i < others.Count; i++)
			{
				this.IgnorarCollosionesConMano(others[i], side, ignore);
			}
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x000143F0 File Offset: 0x000125F0
		public void IgnorarCollosionesConMano(IList<Collider> others, Side side, bool ignore)
		{
			for (int i = 0; i < others.Count; i++)
			{
				this.IgnorarCollosionesConMano(others[i], side, ignore);
			}
		}

		// Token: 0x060006B0 RID: 1712
		public abstract void IgnorarCollosionesConMano(Collider other, Side side, bool ignore);

		// Token: 0x060006B1 RID: 1713 RVA: 0x0001441D File Offset: 0x0001261D
		public virtual void SetCamera(Transform camera)
		{
			this.m_camera = camera.GetComponentNotNull<CamaraAtable>();
			this.m_camera.OnAtada(this);
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00014437 File Offset: 0x00012637
		public virtual void ClearCamera()
		{
			CamaraAtable camaraAtable = this.m_camera.Coalescing<CamaraAtable>();
			if (camaraAtable != null)
			{
				camaraAtable.OnDesatada();
			}
			this.m_camera = null;
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00014456 File Offset: 0x00012656
		public T GetComponentEnRoot<T>()
		{
			return this.GetComponentEnRoot(false);
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x0001445F File Offset: 0x0001265F
		public T GetComponentNotNull<T>() where T : Component
		{
			return this.GetComponentNotNull<T>();
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x0001447B File Offset: 0x0001267B
		Transform ICharacterRoot.get_transform()
		{
			return base.transform;
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00014483 File Offset: 0x00012683
		T ICharacterRoot.GetComponentInChildren<T>()
		{
			return base.GetComponentInChildren<T>();
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x0001448B File Offset: 0x0001268B
		T ICharacterRoot.GetComponentInParent<T>()
		{
			return base.GetComponentInParent<T>();
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00014493 File Offset: 0x00012693
		T ICharacterRoot.GetComponentInParent<T>(bool includeInactive)
		{
			return base.GetComponentInParent<T>(includeInactive);
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0001449C File Offset: 0x0001269C
		T ICharacterRoot.GetComponentInChildren<T>(bool includeInactive)
		{
			return base.GetComponentInChildren<T>(includeInactive);
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x000144A5 File Offset: 0x000126A5
		T ICharacterRoot.GetComponent<T>()
		{
			return base.GetComponent<T>();
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x000144AD File Offset: 0x000126AD
		void ICharacterRoot.GetComponentsInChildren<T>(List<T> results)
		{
			base.GetComponentsInChildren<T>(results);
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x000144B6 File Offset: 0x000126B6
		void ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive, List<T> result)
		{
			base.GetComponentsInChildren<T>(includeInactive, result);
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x000144C0 File Offset: 0x000126C0
		T[] ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive)
		{
			return base.GetComponentsInChildren<T>(includeInactive);
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x000144C9 File Offset: 0x000126C9
		Coroutine ICharacterRoot.StartCoroutine(IEnumerator routine)
		{
			return base.StartCoroutine(routine);
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x000144D2 File Offset: 0x000126D2
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x000144DA File Offset: 0x000126DA
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x040003D4 RID: 980
		[SerializeField]
		private bool m_noRegistrar;

		// Token: 0x040003D5 RID: 981
		private Guid m_ID_Unico;

		// Token: 0x040003D6 RID: 982
		[ReadOnlyUI]
		[SerializeField]
		private string m_ID_UnicoString;

		// Token: 0x040003D7 RID: 983
		[ReadOnlyUI]
		[SerializeField]
		private string m_nombreCompleto;

		// Token: 0x040003D8 RID: 984
		[ReadOnlyUI]
		[SerializeField]
		private string m_Nombre;

		// Token: 0x040003D9 RID: 985
		[ReadOnlyUI]
		[SerializeField]
		private string m_Apellido;

		// Token: 0x040003DA RID: 986
		[ReadOnlyUI]
		[SerializeField]
		private bool m_isBinded;

		// Token: 0x040003DB RID: 987
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_armatureOrientationOffSet;

		// Token: 0x040003DC RID: 988
		public Transform flagMoveTo;

		// Token: 0x040003DF RID: 991
		private CamaraAtable m_camera;

		// Token: 0x040003E0 RID: 992
		private bool m_apareienciaFisicaLoaded;

		// Token: 0x040003E4 RID: 996
		private bool m_memoryApareienciaFisicaLoaded;

		// Token: 0x040003E8 RID: 1000
		private bool m_AILoaded;

		// Token: 0x040003EC RID: 1004
		[SerializeField]
		private ModificableDeBool m_isLoadedAND = new ModificableDeBool(true);

		// Token: 0x040003F3 RID: 1011
		private bool m_isMemoryLoaded;

		// Token: 0x020001A1 RID: 417
		// (Invoke) Token: 0x06000F02 RID: 3842
		public delegate void MovingHandler(ref Vector3 position, ref Quaternion rotation);

		// Token: 0x020001A2 RID: 418
		// (Invoke) Token: 0x06000F06 RID: 3846
		public delegate void MovedHandler(Vector3 position, Quaternion rotation);
	}
}
