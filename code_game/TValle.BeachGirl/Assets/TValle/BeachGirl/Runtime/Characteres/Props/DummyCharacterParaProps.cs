using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Characteres.Props
{
	// Token: 0x020000B9 RID: 185
	public class DummyCharacterParaProps : CustomMonobehaviour, ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable, IMaleCharacter, ICharacterUnico, IPertenecibleDeCharacter, IPropCharacter
	{
		// Token: 0x17000218 RID: 536
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x00011EAB File Offset: 0x000100AB
		public IGrabableProp prop
		{
			get
			{
				return this.m_prop;
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x00011EB3 File Offset: 0x000100B3
		public IReadOnlyList<Collider> colliders
		{
			get
			{
				return this.m_colliders;
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00011EBC File Offset: 0x000100BC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
			this.m_id = Guid.NewGuid();
			Collider[] componentsInChildren = base.GetComponentsInChildren<Collider>(true);
			this.m_colliders = new HashSetList<Collider>(componentsInChildren);
			this.m_collidersParents = new HashSetList<Transform>(componentsInChildren.Select((Collider c) => c.transform).Distinct<Transform>());
			this.m_collidersRigidsTransforms = new HashSetList<Transform>((from c in componentsInChildren
				where c.attachedRigidbody != null
				select c.attachedRigidbody.transform).Distinct<Transform>());
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x00011F82 File Offset: 0x00010182
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (Singleton<CharacteresActivos>.IsInScene && base.isActiveAndEnabled && base.isStared)
			{
				Singleton<CharacteresActivos>.instance.Registrar(this);
			}
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x00011FAC File Offset: 0x000101AC
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<CharacteresActivos>.IsInScene)
			{
				Singleton<CharacteresActivos>.instance.Unregistrar(this);
			}
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x00011FC7 File Offset: 0x000101C7
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (this.m_prop == null)
			{
				this.m_prop = base.GetComponentInChildren<IGrabableProp>(true);
				yield return null;
			}
			if (Singleton<CharacteresActivos>.IsInScene)
			{
				Singleton<CharacteresActivos>.instance.Registrar(this);
			}
			yield break;
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x00011FD6 File Offset: 0x000101D6
		public Sexo sexo
		{
			get
			{
				return Sexo.noDefinido;
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x00011FD9 File Offset: 0x000101D9
		public bool isAlive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x00011FDC File Offset: 0x000101DC
		public float escala
		{
			get
			{
				if (!(this.m_Animator != null))
				{
					return 1f;
				}
				return this.m_Animator.transform.lossyScale.Escala();
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x00012007 File Offset: 0x00010207
		public Vector3 worldHeadPosition
		{
			get
			{
				return base.transform.position;
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x00012014 File Offset: 0x00010214
		public Vector3 worldFirstPersonViewPoint
		{
			get
			{
				return base.transform.position;
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x00012021 File Offset: 0x00010221
		public Transform animatorRootMotionTransform
		{
			get
			{
				return this.m_Animator.transform;
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x0001202E File Offset: 0x0001022E
		public Transform rootBoneTransform
		{
			get
			{
				return this.m_Animator.transform;
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x0001203B File Offset: 0x0001023B
		public Transform hips
		{
			get
			{
				return this.m_Animator.transform;
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x00012048 File Offset: 0x00010248
		public Vector3 posicion
		{
			get
			{
				return base.transform.position;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x00012055 File Offset: 0x00010255
		public Quaternion rotacion
		{
			get
			{
				return base.transform.rotation;
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x00012062 File Offset: 0x00010262
		public bool loaded
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x00012065 File Offset: 0x00010265
		public bool memoryApareienciaFisicaLoaded
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x00012068 File Offset: 0x00010268
		public bool apareienciaFisicaLoaded
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x0001206B File Offset: 0x0001026B
		public Vector3 centerOfMassVelocity
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x00012072 File Offset: 0x00010272
		public Quaternion centerOfMassRotation
		{
			get
			{
				return this.m_Animator.transform.rotation;
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x00012084 File Offset: 0x00010284
		public Vector3 centerOfMassUpDirection
		{
			get
			{
				return this.m_Animator.transform.up;
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x00012096 File Offset: 0x00010296
		public Vector3 centerOfMassForwardDirection
		{
			get
			{
				return this.m_Animator.transform.forward;
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000581 RID: 1409 RVA: 0x000120A8 File Offset: 0x000102A8
		public Vector3 centerOfMassRightDirection
		{
			get
			{
				return this.m_Animator.transform.right;
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x000120BA File Offset: 0x000102BA
		public Vector3 centerOfMassPosition
		{
			get
			{
				return this.m_Animator.transform.position;
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x000120CC File Offset: 0x000102CC
		public Animator bodyAnimator
		{
			get
			{
				return this.m_Animator;
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x000120D4 File Offset: 0x000102D4
		public ICharacter master
		{
			get
			{
				return MainChar.current;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x000120DB File Offset: 0x000102DB
		public virtual IPene peneDeCharacter
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x000120DE File Offset: 0x000102DE
		public virtual IPene dedoPeneDeCharacter
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x000120E1 File Offset: 0x000102E1
		public Guid ID_Unico
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x000120E9 File Offset: 0x000102E9
		public string nombreCompleto
		{
			get
			{
				return base.name;
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x000120F1 File Offset: 0x000102F1
		public string nombre
		{
			get
			{
				return base.name;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x000120F9 File Offset: 0x000102F9
		public string apellido
		{
			get
			{
				return base.name;
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x00012101 File Offset: 0x00010301
		public virtual float estatura
		{
			get
			{
				return this.m_prop.worldLength;
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x0001210E File Offset: 0x0001030E
		public Transform trasnformParaComunicarse
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x00012111 File Offset: 0x00010311
		public float defaultEstatura
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x00012118 File Offset: 0x00010318
		public float defaultHandWidth
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x0001211F File Offset: 0x0001031F
		public float defaultHandHeight
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x00012126 File Offset: 0x00010326
		public string ID_UnicoString
		{
			get
			{
				return this.m_id.ToString();
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x00012139 File Offset: 0x00010339
		public ICharacter inmediateOwner
		{
			get
			{
				return this.master;
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x00012141 File Offset: 0x00010341
		ICharacter ICharacterTeleportable.self
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000593 RID: 1427 RVA: 0x00012144 File Offset: 0x00010344
		// (remove) Token: 0x06000594 RID: 1428 RVA: 0x0001217C File Offset: 0x0001037C
		public event Action<ICharacter> loadingApareienciaFisica;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000595 RID: 1429 RVA: 0x000121B4 File Offset: 0x000103B4
		// (remove) Token: 0x06000596 RID: 1430 RVA: 0x000121EC File Offset: 0x000103EC
		public event Action<ICharacter> onLoadApareienciaFisica;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000597 RID: 1431 RVA: 0x00012224 File Offset: 0x00010424
		// (remove) Token: 0x06000598 RID: 1432 RVA: 0x0001225C File Offset: 0x0001045C
		public event Action<ICharacter> loadedApareienciaFisica;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06000599 RID: 1433 RVA: 0x00012294 File Offset: 0x00010494
		// (remove) Token: 0x0600059A RID: 1434 RVA: 0x000122CC File Offset: 0x000104CC
		public event Action<ICharacter> memoryLoadingApareienciaFisica;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x0600059B RID: 1435 RVA: 0x00012304 File Offset: 0x00010504
		// (remove) Token: 0x0600059C RID: 1436 RVA: 0x0001233C File Offset: 0x0001053C
		public event Action<ICharacter> memoryOnLoadApareienciaFisica;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x0600059D RID: 1437 RVA: 0x00012374 File Offset: 0x00010574
		// (remove) Token: 0x0600059E RID: 1438 RVA: 0x000123AC File Offset: 0x000105AC
		public event Action<ICharacter> memoryLoadedApareienciaFisica;

		// Token: 0x0600059F RID: 1439 RVA: 0x000123E1 File Offset: 0x000105E1
		public T GetComponentEnRoot<T>()
		{
			return base.GetComponentInChildren<T>();
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x000123E9 File Offset: 0x000105E9
		public void IgnorarCollosionesConMano(IReadOnlyList<Collider> others, Side side, bool ignore)
		{
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x000123EB File Offset: 0x000105EB
		public void IgnorarCollosionesConMano(IList<Collider> others, Side side, bool ignore)
		{
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x000123ED File Offset: 0x000105ED
		public void IgnorarCollosionesConMano(Collider other, Side side, bool ignore)
		{
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x000123EF File Offset: 0x000105EF
		public void IgnorarCollosionesConManos(IReadOnlyList<Collider> others, bool ignore)
		{
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x000123F1 File Offset: 0x000105F1
		public void IgnorarCollosionesConManos(IList<Collider> others, bool ignore)
		{
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x000123F3 File Offset: 0x000105F3
		public void IgnorarCollosionesConManos(Collider other, bool ignore)
		{
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x000123F5 File Offset: 0x000105F5
		public bool ObjetoEsMiAnteBrazo(Transform obj)
		{
			return false;
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x000123F8 File Offset: 0x000105F8
		public bool ObjetoEsMiDedo(Collider obj)
		{
			return false;
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x000123FB File Offset: 0x000105FB
		public bool ObjetoEsMiDedo(Rigidbody obj)
		{
			return false;
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x000123FE File Offset: 0x000105FE
		public bool ObjetoEsMiDedo(Transform obj)
		{
			return false;
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x00012401 File Offset: 0x00010601
		public bool ObjetoEsMiDedo(Component obj)
		{
			return false;
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x00012404 File Offset: 0x00010604
		public bool ObjetoEsMiMano(Collider obj)
		{
			return false;
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x00012407 File Offset: 0x00010607
		public bool ObjetoEsMiMano(Rigidbody obj)
		{
			return false;
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0001240A File Offset: 0x0001060A
		public bool ObjetoEsMiMano(Transform obj)
		{
			return false;
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0001240D File Offset: 0x0001060D
		public bool ObjetoEsMiPene(Transform obj)
		{
			return false;
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00012410 File Offset: 0x00010610
		public bool ObjetoEsMiPene(Rigidbody obj)
		{
			return false;
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00012413 File Offset: 0x00010613
		public bool ObjetoEsMiPene(Collider obj)
		{
			return false;
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00012416 File Offset: 0x00010616
		public bool ObjetoEsMiPene(Component obj)
		{
			return false;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00012419 File Offset: 0x00010619
		public bool ObjetoEsMiPierna(Collider obj)
		{
			return false;
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0001241C File Offset: 0x0001061C
		public bool ObjetoEsMiPierna(Rigidbody obj)
		{
			return false;
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0001241F File Offset: 0x0001061F
		public bool ObjetoEsMiPierna(Transform obj)
		{
			return false;
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00012422 File Offset: 0x00010622
		public bool ObjetoEsMiTorzo(Collider obj)
		{
			return false;
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x00012425 File Offset: 0x00010625
		public bool ObjetoEsMiTorzo(Rigidbody obj)
		{
			return false;
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x00012428 File Offset: 0x00010628
		public bool ObjetoEsMiTorzo(Transform obj)
		{
			return false;
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0001242C File Offset: 0x0001062C
		public virtual bool ObjetoEsProp(Transform obj)
		{
			Transform skeletonRoot = this.m_prop.skeletonRoot;
			Transform physcisRoot = this.m_prop.physcisRoot;
			return (physcisRoot != null && obj.IsChildOf(physcisRoot)) || (skeletonRoot != null && obj.IsChildOf(skeletonRoot)) || this.m_collidersParents.Contains(obj) || this.m_collidersRigidsTransforms.Contains(obj);
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00012491 File Offset: 0x00010691
		public bool ObjetoMePertenece(Transform obj)
		{
			return obj.IsChildOf(base.transform) || this.ObjetoEsProp(obj);
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x000124AA File Offset: 0x000106AA
		public void SetPositionAndRotation(Transform targetTransform)
		{
			this.SetPositionAndRotation(targetTransform.position, targetTransform.rotation);
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x000124BE File Offset: 0x000106BE
		public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
		{
			base.transform.SetPositionAndRotation(position, rotation);
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x000124CD File Offset: 0x000106CD
		public T GetComponentNotNull<T>() where T : Component
		{
			throw new NotImplementedException();
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x000124DC File Offset: 0x000106DC
		Transform ICharacterRoot.get_transform()
		{
			return base.transform;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x000124E4 File Offset: 0x000106E4
		T ICharacterRoot.GetComponentInChildren<T>()
		{
			return base.GetComponentInChildren<T>();
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x000124EC File Offset: 0x000106EC
		T ICharacterRoot.GetComponentInParent<T>()
		{
			return base.GetComponentInParent<T>();
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x000124F4 File Offset: 0x000106F4
		T ICharacterRoot.GetComponentInParent<T>(bool includeInactive)
		{
			return base.GetComponentInParent<T>(includeInactive);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x000124FD File Offset: 0x000106FD
		T ICharacterRoot.GetComponentInChildren<T>(bool includeInactive)
		{
			return base.GetComponentInChildren<T>(includeInactive);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00012506 File Offset: 0x00010706
		T ICharacterRoot.GetComponent<T>()
		{
			return base.GetComponent<T>();
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0001250E File Offset: 0x0001070E
		void ICharacterRoot.GetComponentsInChildren<T>(List<T> results)
		{
			base.GetComponentsInChildren<T>(results);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00012517 File Offset: 0x00010717
		void ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive, List<T> result)
		{
			base.GetComponentsInChildren<T>(includeInactive, result);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00012521 File Offset: 0x00010721
		T[] ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive)
		{
			return base.GetComponentsInChildren<T>(includeInactive);
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0001252A File Offset: 0x0001072A
		Coroutine ICharacterRoot.StartCoroutine(IEnumerator routine)
		{
			return base.StartCoroutine(routine);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00012533 File Offset: 0x00010733
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0001253B File Offset: 0x0001073B
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400039F RID: 927
		[SerializeField]
		private Animator m_Animator;

		// Token: 0x040003A0 RID: 928
		private IGrabableProp m_prop;

		// Token: 0x040003A1 RID: 929
		private Guid m_id;

		// Token: 0x040003A2 RID: 930
		private HashSetList<Collider> m_colliders;

		// Token: 0x040003A3 RID: 931
		private HashSetList<Transform> m_collidersParents;

		// Token: 0x040003A4 RID: 932
		private HashSetList<Transform> m_collidersRigidsTransforms;
	}
}
