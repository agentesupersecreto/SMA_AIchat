using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Bones.Runtime.V2.ConstraintsV2.Users;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime.Constraints.Penes;
using Assets._ReusableScripts.CuchiCuchi.Penes;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using Assets._ReusableScripts.PhysicsScripts.JointAdmins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000D1 RID: 209
	[RequireComponent(typeof(PenisLinearChain))]
	public abstract class Penetrador : CustomUpdatedMonobehaviourBase, IPenisPenetratiosCallbacks, IPeneConPartes, IPene, IPertenecibleDeCharacter, IComponentStartable, IPeneSimple, IPeneCallbacks, IPeneCresiente, IPeneRigido, IPeneEstirable, IEstirable, IJointSuavisableV2, IFixableSuavisableJointAdmin, IFixableJointAdmin, IPeneIntentadorDePenetracion
	{
		// Token: 0x06000756 RID: 1878 RVA: 0x000164A0 File Offset: 0x000146A0
		private float CalculateDistanceFromTipToHoleEntrada(IHole to)
		{
			Vector3 position = to.entrada.position;
			Vector3 vector;
			Vector3 vector2;
			Vector3 vector3;
			this.GetPuntaStartTipWorldPositions(1f, out vector, out vector2, out vector3);
			return Vector3.Distance(Math3d.ProjectPointOnLineSegment(vector, vector2, position), position);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x000164D8 File Offset: 0x000146D8
		void IPeneIntentadorDePenetracion.DeclararIntentando(IHole to, int frameID)
		{
			if (to == null)
			{
				return;
			}
			float num = this.CalculateDistanceFromTipToHoleEntrada(to);
			for (int i = this.m_holesIntentando.Count - 1; i >= 0; i--)
			{
				Penetrador.HoleEntry holeEntry = this.m_holesIntentando[i];
				IHole hole;
				if (!holeEntry.hole.TryGetTarget(out hole) || hole == null)
				{
					this.m_holesIntentando.RemoveAt(i);
				}
				else if (hole == to)
				{
					holeEntry.distance = num;
					holeEntry.frameID = frameID;
					return;
				}
			}
			this.m_holesIntentando.Add(new Penetrador.HoleEntry
			{
				hole = new WeakReference<IHole>(to),
				distance = num,
				frameID = frameID
			});
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00016574 File Offset: 0x00014774
		bool IPeneIntentadorDePenetracion.Closest(IHole to)
		{
			if (to == null)
			{
				return false;
			}
			if (this.m_holesIntentando.Count == 0)
			{
				return true;
			}
			IHole hole = null;
			float num = float.MaxValue;
			int id = UpdateAutoId.current.id;
			for (int i = this.m_holesIntentando.Count - 1; i >= 0; i--)
			{
				Penetrador.HoleEntry holeEntry = this.m_holesIntentando[i];
				IHole hole2;
				if (!holeEntry.hole.TryGetTarget(out hole2) || hole2 == null)
				{
					this.m_holesIntentando.RemoveAt(i);
				}
				else if (id - holeEntry.frameID > 1)
				{
					this.m_holesIntentando.RemoveAt(i);
				}
				else if (holeEntry.distance < num)
				{
					hole = hole2;
					num = holeEntry.distance;
				}
			}
			return this.m_holesIntentando.Count == 0 || hole == null || hole == to;
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x0001663F File Offset: 0x0001483F
		bool IEstirable.defaultEstirableEstate
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x0600075A RID: 1882 RVA: 0x00016642 File Offset: 0x00014842
		bool IEstirable.currentEstirableEstate
		{
			get
			{
				return this.m_penisLinearChain.puedeEstirar;
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x0001664F File Offset: 0x0001484F
		ModificableDeBool IEstirable.estirandoOR
		{
			get
			{
				return this.m_penisLinearChain.puedeEstirarModificable;
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x0001665C File Offset: 0x0001485C
		DriversDeJointModificable IJointSuavisableV2.suavisable
		{
			get
			{
				return ((IJointSuavisableV2)this.m_penisLinearChain).suavisable;
			}
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00016669 File Offset: 0x00014869
		void IFixableSuavisableJointAdmin.FixSuavizacion()
		{
			((IFixableSuavisableJointAdmin)this.m_penisLinearChain).FixSuavizacion();
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x00016676 File Offset: 0x00014876
		void IFixableJointAdmin.Fix()
		{
			((IFixableJointAdmin)this.m_penisLinearChain).Fix();
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x0600075F RID: 1887
		public abstract Renderer mainRenderer { get; }

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000760 RID: 1888
		public abstract IReadOnlyList<Renderer> allRenderer { get; }

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x00016684 File Offset: 0x00014884
		public bool isVisible
		{
			get
			{
				Renderer mainRenderer = this.mainRenderer;
				return ((mainRenderer != null) ? new bool?(mainRenderer.isVisible) : null).GetValueOrDefault(true);
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000762 RID: 1890 RVA: 0x000166B9 File Offset: 0x000148B9
		public ICharacter inmediateOwner
		{
			get
			{
				return this.m_inmediateOwner;
			}
		}

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x06000763 RID: 1891 RVA: 0x000166C4 File Offset: 0x000148C4
		// (remove) Token: 0x06000764 RID: 1892 RVA: 0x000166FC File Offset: 0x000148FC
		public event IPenePenetratingHandler entered;

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x06000765 RID: 1893 RVA: 0x00016734 File Offset: 0x00014934
		// (remove) Token: 0x06000766 RID: 1894 RVA: 0x0001676C File Offset: 0x0001496C
		public event IPenePenetratingHandler stayed;

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x06000767 RID: 1895 RVA: 0x000167A4 File Offset: 0x000149A4
		// (remove) Token: 0x06000768 RID: 1896 RVA: 0x000167DC File Offset: 0x000149DC
		public event IPenePenetratingHandler exited;

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x06000769 RID: 1897 RVA: 0x00016814 File Offset: 0x00014A14
		// (remove) Token: 0x0600076A RID: 1898 RVA: 0x0001684C File Offset: 0x00014A4C
		public event IPeneCallbacksHandler peneTryingEnterInHole;

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x0600076B RID: 1899 RVA: 0x00016884 File Offset: 0x00014A84
		// (remove) Token: 0x0600076C RID: 1900 RVA: 0x000168BC File Offset: 0x00014ABC
		public event IPeneCallbacksHandler peneEnteredInHole;

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x0600076D RID: 1901 RVA: 0x000168F4 File Offset: 0x00014AF4
		// (remove) Token: 0x0600076E RID: 1902 RVA: 0x0001692C File Offset: 0x00014B2C
		public event IPeneCallbacksHandler peneStayedInHole;

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x0600076F RID: 1903 RVA: 0x00016964 File Offset: 0x00014B64
		// (remove) Token: 0x06000770 RID: 1904 RVA: 0x0001699C File Offset: 0x00014B9C
		public event IPeneCallbacksHandler peneExitedInHole;

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000771 RID: 1905 RVA: 0x000169D1 File Offset: 0x00014BD1
		public int countDePartes
		{
			get
			{
				return this.penisLinearChain.cantidadDePuntos + 1;
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x000169E0 File Offset: 0x00014BE0
		public sealed override int updateEvent1Index
		{
			get
			{
				return (int)this.m_UpdateEvent;
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000773 RID: 1907 RVA: 0x000169E8 File Offset: 0x00014BE8
		public PenisPart @base
		{
			get
			{
				return this.m_dicPointToPart[this.m_penisLinearChain.rootPunto];
			}
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x00016A00 File Offset: 0x00014C00
		public PenisPart punta
		{
			get
			{
				return this.m_dicPointToPart[this.m_penisLinearChain.last];
			}
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x00016A18 File Offset: 0x00014C18
		public PenisPart puntaParte
		{
			get
			{
				return this.punta;
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x00016A20 File Offset: 0x00014C20
		public PenisLinearChain penisLinearChain
		{
			get
			{
				return this.m_penisLinearChain;
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x00016A28 File Offset: 0x00014C28
		public PhysicMaterial physicMaterial
		{
			get
			{
				return this.m_PhysicMaterial;
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x00016A30 File Offset: 0x00014C30
		public ModificableDeFloat anguloContraGravedadAdder
		{
			get
			{
				return this.m_anguloContraGravedadAdder;
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x00016A38 File Offset: 0x00014C38
		float IPene.timeTryingToOpenHoleMod
		{
			get
			{
				return this.timeTryingToOpenHoleModificador;
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x0600077A RID: 1914 RVA: 0x00016A40 File Offset: 0x00014C40
		public ModificableDeFloat erectionModificable
		{
			get
			{
				return this.m_erectionModificable;
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x00016A48 File Offset: 0x00014C48
		public bool hidden
		{
			get
			{
				return ExtendedMonoBehaviour.AlmostEqual(this.m_CurrentErection, 0f, 0.002f);
			}
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x00016A5F File Offset: 0x00014C5F
		// (set) Token: 0x0600077D RID: 1917 RVA: 0x00016A67 File Offset: 0x00014C67
		[Obsolete("", true)]
		public float erection
		{
			get
			{
				return this.m_ErectionTarget;
			}
			set
			{
				this.m_ErectionTarget = Mathf.Clamp(value, 0f, 100f);
			}
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x00016A7F File Offset: 0x00014C7F
		public void SetErectionTarget(float value)
		{
			this.m_ErectionTarget = Mathf.Clamp(value, 0f, 100f);
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x00016A97 File Offset: 0x00014C97
		public float cleanErectionTarget
		{
			get
			{
				return this.m_ErectionTarget;
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x00016A9F File Offset: 0x00014C9F
		public float moddedErectionTarget
		{
			get
			{
				return Mathf.Clamp(this.m_erectionModificable.ModificarValor(this.m_ErectionTarget), 1f, 100f);
			}
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x00016AC1 File Offset: 0x00014CC1
		public float currentRealErectionValue
		{
			get
			{
				return this.m_CurrentErection;
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000782 RID: 1922 RVA: 0x00016AC9 File Offset: 0x00014CC9
		// (set) Token: 0x06000783 RID: 1923 RVA: 0x00016AD1 File Offset: 0x00014CD1
		public float largo
		{
			get
			{
				return this.m_largo;
			}
			set
			{
				this.m_largo = Mathf.Clamp(value, 0f, 10f);
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x00016AE9 File Offset: 0x00014CE9
		// (set) Token: 0x06000785 RID: 1925 RVA: 0x00016AF1 File Offset: 0x00014CF1
		public float ancho
		{
			get
			{
				return this.m_ancho;
			}
			set
			{
				this.m_ancho = Mathf.Clamp(value, 0f, 10f);
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x00016B09 File Offset: 0x00014D09
		// (set) Token: 0x06000787 RID: 1927 RVA: 0x00016B11 File Offset: 0x00014D11
		public float rigidez
		{
			get
			{
				return this.m_rigidez;
			}
			set
			{
				this.m_rigidez = Mathf.Clamp(value, 0.1f, 10f);
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x00016B29 File Offset: 0x00014D29
		public Transform skinSurfaceTransform
		{
			get
			{
				return this.m_skinSurfaceTransform;
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x00016B31 File Offset: 0x00014D31
		public Vector3 posicionDeBase
		{
			get
			{
				return this.m_penisLinearChain.rootPunto.jointRigidbody.position;
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x00016B48 File Offset: 0x00014D48
		public int lastInsideIndex
		{
			get
			{
				for (int i = this.m_penisPartsInOrder.Count - 1; i >= 0; i--)
				{
					if (this.m_penisPartsInOrder[i].inside)
					{
						return i;
					}
				}
				return -1;
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x00016B84 File Offset: 0x00014D84
		public int firstInsideIndex
		{
			get
			{
				for (int i = 0; i < this.m_penisPartsInOrder.Count; i++)
				{
					if (this.m_penisPartsInOrder[i].inside)
					{
						return i;
					}
				}
				return -1;
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x00016BBD File Offset: 0x00014DBD
		public IReadOnlyList<PenisPart> partesEnOrden
		{
			get
			{
				return this.m_penisPartsInOrder;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x00016BC5 File Offset: 0x00014DC5
		public IEnumerable<PenisPart> enumerator
		{
			get
			{
				return this.m_penisPartsInOrder;
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x0600078E RID: 1934 RVA: 0x00016BD0 File Offset: 0x00014DD0
		public int lastInMiddleIndex
		{
			get
			{
				for (int i = this.m_penisPartsInOrder.Count - 1; i >= 0; i--)
				{
					if (this.m_penisPartsInOrder[i].inMiddle)
					{
						return i;
					}
				}
				return -1;
			}
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00016C0C File Offset: 0x00014E0C
		public PenisPart ObtenerParte(PenisPoint point)
		{
			PenisPart penisPart;
			if (this.m_dicPointToPart.TryGetValue(point, out penisPart))
			{
				return penisPart;
			}
			return null;
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x00016C2C File Offset: 0x00014E2C
		public bool isPenetrating
		{
			get
			{
				for (int i = 0; i < this.m_penisPartsInOrder.Count; i++)
				{
					if (this.m_penisPartsInOrder[i].inside)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x00016C65 File Offset: 0x00014E65
		public bool wasBlocked
		{
			get
			{
				return this.m_blocked;
			}
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x00016C6D File Offset: 0x00014E6D
		public Transform scalerTransform
		{
			get
			{
				return this.m_penisLinearChain.puntoBaseTransform;
			}
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x00016C7A File Offset: 0x00014E7A
		[Obsolete("Las partes tienen anchos diferentes", true)]
		public float worldWidth
		{
			get
			{
				return this.m_worldTipPartAncho;
			}
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x00016C82 File Offset: 0x00014E82
		[Obsolete("Las partes tienen largos diferentes", true)]
		public float worldPartLength
		{
			get
			{
				return this.m_worldTipPartlargo;
			}
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000795 RID: 1941 RVA: 0x00016C8A File Offset: 0x00014E8A
		public float worldTipPartWidth
		{
			get
			{
				return this.m_worldTipPartAncho;
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000796 RID: 1942 RVA: 0x00016C92 File Offset: 0x00014E92
		public float worldTipPartLength
		{
			get
			{
				return this.m_worldTipPartlargo;
			}
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000797 RID: 1943 RVA: 0x00016C9A File Offset: 0x00014E9A
		public float worldLength
		{
			get
			{
				return this.m_worldlargo;
			}
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000798 RID: 1944 RVA: 0x00016CA2 File Offset: 0x00014EA2
		public float worldLengthFromUnderSkin
		{
			get
			{
				return this.m_worldLengthFromUnderSkin;
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x00016CAA File Offset: 0x00014EAA
		public float realCurrentWorldLengthFromUnderSkin
		{
			get
			{
				return this.m_realCurrentWorldLengthFromUnderSkin;
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x0600079A RID: 1946 RVA: 0x00016CB2 File Offset: 0x00014EB2
		public float penetratingLengthMod
		{
			get
			{
				return this.m_worldlargoInsideHoleMod;
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x00016CBA File Offset: 0x00014EBA
		public float penetratingWorldLength
		{
			get
			{
				return this.m_worldlargoInsideHole;
			}
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x0600079C RID: 1948 RVA: 0x00016CC2 File Offset: 0x00014EC2
		public Transform tipPhysics
		{
			get
			{
				return this.m_penisLinearChain.tipPhysicBone;
			}
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x00016CCF File Offset: 0x00014ECF
		public Transform root
		{
			get
			{
				return this.m_penisLinearChain.puntoBaseTransform;
			}
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x0600079E RID: 1950 RVA: 0x00016CDC File Offset: 0x00014EDC
		Transform IPene.parteBase
		{
			get
			{
				return this.@base.physicBone.transform;
			}
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x0600079F RID: 1951 RVA: 0x00016CEE File Offset: 0x00014EEE
		Transform IPene.partePunta
		{
			get
			{
				return this.punta.physicBone.transform;
			}
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x060007A0 RID: 1952 RVA: 0x00016D00 File Offset: 0x00014F00
		public GameObject peneObjeto
		{
			get
			{
				return base.gameObject;
			}
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x060007A1 RID: 1953 RVA: 0x00016D08 File Offset: 0x00014F08
		public float worldScaleIgnorandoEreccion
		{
			get
			{
				return this.m_worldScale / this.m_largoErectionMod;
			}
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x060007A2 RID: 1954 RVA: 0x00016D17 File Offset: 0x00014F17
		public float worldScale
		{
			get
			{
				return this.m_worldScale;
			}
		}

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x00016D1F File Offset: 0x00014F1F
		public float worldLossyScale
		{
			get
			{
				return this.m_worldLossyScale;
			}
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x060007A4 RID: 1956 RVA: 0x00016D27 File Offset: 0x00014F27
		public float totalMass
		{
			get
			{
				return this.m_penisLinearChain.totalMass;
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x060007A5 RID: 1957 RVA: 0x00016D34 File Offset: 0x00014F34
		public Vector3 rootDefaultForwardWorldDirection
		{
			get
			{
				return this.m_penisLinearChain.currentDefaultWorldForwardDirection;
			}
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x060007A6 RID: 1958 RVA: 0x00016D41 File Offset: 0x00014F41
		public float worldMaxWidth
		{
			get
			{
				return this.m_worldMaxPartWidth;
			}
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x060007A7 RID: 1959 RVA: 0x00016D49 File Offset: 0x00014F49
		public float worldMaxWidthOrTipLength
		{
			get
			{
				return this.m_worldMaxWidthOrTipLength;
			}
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x060007A8 RID: 1960
		public abstract Transform lookAtTarget { get; }

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x060007A9 RID: 1961 RVA: 0x00016D54 File Offset: 0x00014F54
		// (remove) Token: 0x060007AA RID: 1962 RVA: 0x00016D8C File Offset: 0x00014F8C
		public event Action onHiddenStateChanged;

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x060007AB RID: 1963 RVA: 0x00016DC4 File Offset: 0x00014FC4
		// (remove) Token: 0x060007AC RID: 1964 RVA: 0x00016DFC File Offset: 0x00014FFC
		public event Action onUpdated;

		// Token: 0x060007AD RID: 1965
		public abstract bool IsBlocked();

		// Token: 0x060007AE RID: 1966 RVA: 0x00016E34 File Offset: 0x00015034
		public void ShrinkToRoot()
		{
			Vector3 position = this.penisLinearChain.rootPunto.jointRigidbody.transform.position;
			Quaternion rotation = this.penisLinearChain.rootPunto.jointRigidbody.transform.rotation;
			foreach (PenisPart penisPart in this.m_penisPartsInOrder)
			{
				penisPart.physicBone.transform.position = position;
				penisPart.physicBone.transform.rotation = rotation;
			}
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00016ED8 File Offset: 0x000150D8
		public void SetPhysicMaterial(PhysicMaterial m)
		{
			if (base.isStared)
			{
				throw new InvalidOperationException();
			}
			this.m_PhysicMaterial = Object.Instantiate<PhysicMaterial>(m);
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x00016EF4 File Offset: 0x000150F4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_hitSkinnedCharacter = this.GetComponentEnRoot(false);
			this.m_layer = Singleton<ConfiguracionGeneral>.instance.layers.penes;
			this.m_penisLinearChain = base.GetComponent<PenisLinearChain>();
			this.m_penisLinearChain.customUpdatedConfig.manualStart = true;
			this.m_penisLinearChain.scaleChanged += this.M_penisLinearChain_scaleChanged;
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00016F5D File Offset: 0x0001515D
		public void SetSkinSurfaceTransform(Transform skinSurfaceTransform)
		{
			if (base.isStared)
			{
				throw new NotSupportedException();
			}
			this.m_skinSurfaceTransform = skinSurfaceTransform;
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x00016F74 File Offset: 0x00015174
		protected override void StartUnityEvent()
		{
			if (this.m_PhysicMaterial == null)
			{
				this.m_PhysicMaterial = Object.Instantiate<PhysicMaterial>(Singleton<ColecionDePhysicsMaterials>.instance.pene);
			}
			base.StartUnityEvent();
			if (this.m_skinSurfaceTransform == null)
			{
				PeneMaleConstraintsAdder componentEnRoot = this.GetComponentEnRoot(false);
				Transform transform;
				if (componentEnRoot == null)
				{
					transform = null;
				}
				else
				{
					ChildOfGuiaUser baseDePene = componentEnRoot.baseDePene;
					transform = ((baseDePene != null) ? baseDePene.target : null);
				}
				this.m_skinSurfaceTransform = transform;
			}
			base.transform.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = this.m_layer;
			}, true);
			try
			{
				this.m_penisLinearChain.ManualStart();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				throw ex;
			}
			this.AddPartes();
			this.m_defaultLocalRotation = this.penisLinearChain.puntoBaseTransform.localRotation;
			this.m_inmediateOwner = base.GetComponentInParent<ICharacter>();
			this.m_penisLinearChain.ObtenerModificadores("Mod_Ereccion_Penis", this.m_modificadoresDeEreccion, false);
			if (this.m_penisLinearChain.tipBone != null)
			{
				this.m_penisLinearChain.tipBone.parent = this.punta.charBone;
			}
			for (int i = 0; i < this.partesEnOrden.Count; i++)
			{
				PenisPart parte = this.partesEnOrden[i];
				PenisPoint punto = parte.puntoConnectadoAEstaParte;
				ModificadorDeFloat modMain = parte.mainCollider.modificableDeAncho.ObtenerModificadorNotNull(this);
				ModificadorDeFloat modificadorDeFloat = parte.complementoCollider.modificableDeAncho.ObtenerModificadorNotNull(this);
				if (punto.trasnformCopier == null)
				{
					throw new ArgumentNullException("punto.trasnformCopier", "punto.trasnformCopier null reference.");
				}
				this.m_modificadoresDeAnchoDePenePorIndex.Add(i, new Tuple<TrasnformCopier, ModificadorDeFloat, ModificadorDeFloat>(punto.trasnformCopier, modMain, modificadorDeFloat));
				punto.bodyAdmin.volumenGetter = delegate(Rigidbody rigid)
				{
					if (modMain == null)
					{
						throw new ArgumentNullException("modMain", "modMain null reference.");
					}
					float valor = modMain.valor.valor;
					if (valor <= 0f)
					{
						Debug.LogError("ancho mod de parte " + parte.name + " es zero o menor", parte);
					}
					return JointBodyAdmin.GetVol(Vector3.Scale(new Vector3(valor, valor, 1f), punto.scaleProxy.lossyScale));
				};
			}
			this.m_RigidezMod = ((IJointSuavisableV2)this.m_penisLinearChain).suavisable.ObtenerModificadorNotNull(this);
			IHitSkinnedCharacter hitSkinnedCharacter = this.m_hitSkinnedCharacter;
			if (hitSkinnedCharacter != null)
			{
				hitSkinnedCharacter.ReIgnoreSkinSelfCollisions();
			}
			this.m_flagUpdateSize = true;
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00017190 File Offset: 0x00015390
		public void FlagUpdateSizesData()
		{
			this.m_flagUpdateSize = true;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0001719C File Offset: 0x0001539C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_PhysicMaterial != null)
			{
				Object.DestroyImmediate(this.m_PhysicMaterial);
			}
			if (this.m_penisLinearChain)
			{
				this.m_penisLinearChain.scaleChanged += this.M_penisLinearChain_scaleChanged;
			}
			PenisLinearChain penisLinearChain = this.m_penisLinearChain;
			if (penisLinearChain == null)
			{
				return;
			}
			DriversDeJointModificable suavisable = ((IJointSuavisableV2)penisLinearChain).suavisable;
			if (suavisable == null)
			{
				return;
			}
			suavisable.RemoverModificador(this.m_RigidezMod);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x00017210 File Offset: 0x00015410
		public BoneStretchedChain TryGetPenetratingHole()
		{
			int lastInMiddleIndex = this.lastInMiddleIndex;
			if (lastInMiddleIndex < 0)
			{
				return null;
			}
			return this.m_penisPartsInOrder[lastInMiddleIndex].currentPenetratingHole;
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x0001723B File Offset: 0x0001543B
		public bool IsPenetratingHole(out BoneStretchedChain hole)
		{
			hole = null;
			if (this.isPenetrating)
			{
				hole = this.TryGetPenetratingHole();
				return hole != null;
			}
			return false;
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0001725A File Offset: 0x0001545A
		private void M_penisLinearChain_scaleChanged(LinearChainTipo2<PenisPoint, PenisPoint.Configuracion> obj)
		{
			this.m_flagUpdateSize = true;
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00017264 File Offset: 0x00015464
		public override void OnUpdateEvent1()
		{
			this.m_worldScale = this.scalerTransform.lossyScale.Escala();
			this.m_worldLossyScale = this.m_inmediateOwner.escala;
			for (int i = 0; i < this.m_penisPartsInOrder.Count; i++)
			{
				this.m_penisPartsInOrder[i].UpdateState();
			}
			int firstInsideIndex = this.firstInsideIndex;
			for (int j = this.m_penisPartsInOrder.Count - 1; j >= 0; j--)
			{
				this.m_penisPartsInOrder[j].UpdateDeep(firstInsideIndex, this.m_worldScale, 1f);
			}
			for (int k = this.m_penisPartsInOrder.Count - 1; k >= 0; k--)
			{
				this.m_penisPartsInOrder[k].UpdateCollider();
			}
			if (this.apuntarAHoleEnPenetracion)
			{
				this.FixPenisDirection();
			}
			this.UpdateRigidez();
			this.UpdateErectionState();
			this.UpdateSize();
			bool flag = this.UpdateHiddeState();
			for (int l = 0; l < this.partesEnOrden.Count; l++)
			{
				PenisPart penisPart = this.partesEnOrden[l];
				Tuple<TrasnformCopier, ModificadorDeFloat, ModificadorDeFloat> tuple = this.m_modificadoresDeAnchoDePenePorIndex[l];
				tuple.Item1.forceZeroScale = penisPart.penetrationState == PenisPart.PenetrationState.adentroDesactivado;
				if (tuple.Item1.usaScaleMod)
				{
					tuple.Item1.scaleMod = new Vector3(this.m_anchoLast, this.m_anchoLast, 1f);
				}
			}
			this.m_penisLinearChain.SetUserLocalRotation(this.userLocalRotation);
			float num = this.m_anguloContraGravedadAdder.AdicinarValorIncluyendo(this.currentAngleAgainsGravity);
			if (num != this.m_lastAngleAgainsGravity)
			{
				this.m_lastAngleAgainsGravity = num;
				float num2 = Mathf.Lerp(-this.configuracion.angleOnGravityWhenSoft, this.m_penisLinearChain.angleAgaintsGravity, this.m_CurrentErection / 100f);
				num2 += num;
				this.m_penisLinearChain.SetAngleAgainsGravity(num2);
				this.m_defaultLocalRotation = this.penisLinearChain.puntoBaseTransform.localRotation;
			}
			if (flag)
			{
				for (int m = 0; m < this.m_penisPartsInOrder.Count; m++)
				{
					this.m_penisPartsInOrder[m].UpdateHiddenState();
				}
				Action action = this.onHiddenStateChanged;
				if (action != null)
				{
					action();
				}
			}
			Action action2 = this.onUpdated;
			if (action2 == null)
			{
				return;
			}
			action2();
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x000174A9 File Offset: 0x000156A9
		public void Hide()
		{
			this.m_flagToInstantHide = true;
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x000174B4 File Offset: 0x000156B4
		private void UpdateRigidez()
		{
			if (ExtendedMonoBehaviour.AlmostEqual(this.m_rigidezLast, this.m_rigidez, 0.001f))
			{
				return;
			}
			this.m_rigidezLast = this.m_rigidez;
			if (this.m_rigidezLast > 1f)
			{
				this.m_RigidezMod.SetAllTo(this.m_rigidezLast, Mathf.Lerp(1f, this.m_rigidezLast, 0.333f), true);
				return;
			}
			this.m_RigidezMod.SetAllTo(this.m_rigidezLast, true);
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x00017530 File Offset: 0x00015730
		private void UpdateSize()
		{
			float num = this.m_largo * this.m_largoErectionMod;
			if (num == 0f)
			{
				throw new NotImplementedException();
			}
			float num2 = this.m_ancho * this.m_anchoErectionMod / num;
			this.m_realCurrentWorldLengthFromUnderSkin = (this.m_penisLinearChain.puntoBaseTransform.position - this.m_penisLinearChain.tipBone.position).magnitude;
			if (!this.m_flagUpdateSize && ExtendedMonoBehaviour.AlmostEqual(this.m_anchoLast, num2, 0.0001f) && ExtendedMonoBehaviour.AlmostEqual(this.m_largoLast, num, 0.0001f))
			{
				return;
			}
			this.m_flagUpdateSize = false;
			this.m_anchoLast = num2;
			this.m_largoLast = num;
			this.scalerTransform.localScale = new Vector3(num, num, num);
			for (int i = 0; i < this.partesEnOrden.Count; i++)
			{
				PenisPart penisPart = this.partesEnOrden[i];
				Tuple<TrasnformCopier, ModificadorDeFloat, ModificadorDeFloat> tuple = this.m_modificadoresDeAnchoDePenePorIndex[i];
				tuple.Item2.valor.valor = num2;
				tuple.Item3.valor.valor = num2;
				penisPart.mainCollider.UpdateSize(false);
				penisPart.complementoCollider.UpdateSize(false);
				penisPart.puntoConnectadoAEstaParte.bodyAdmin.Fix();
			}
			Vector3 vector = this.m_penisLinearChain.puntoBaseTransform.TransformPoint(this.m_penisLinearChain.defaultTipLocalPositionFromBase);
			this.m_worldLengthFromUnderSkin = (this.m_penisLinearChain.puntoBaseTransform.position - vector).magnitude;
			if (this.m_skinSurfaceTransform != null)
			{
				this.m_worldLengthUnderSkin = Vector3.Distance(this.m_penisLinearChain.puntoBaseTransform.position, this.m_skinSurfaceTransform.position);
			}
			else
			{
				this.m_worldLengthUnderSkin = 0f;
			}
			this.m_worldlargo = Mathf.Clamp(this.m_worldLengthFromUnderSkin - this.m_worldLengthUnderSkin, 0f, float.MaxValue);
			this.m_worldTipPartAncho = this.m_worldScale * this.m_penisLinearChain.anchoLocalDePunta;
			this.m_worldTipPartlargo = this.m_worldScale * this.m_penisLinearChain.largoLocalDePunta;
			this.m_worldMaxPartWidth = 0f;
			for (int j = 0; j < this.m_penisPartsInOrder.Count; j++)
			{
				this.m_worldMaxPartWidth = Mathf.Max(this.m_worldMaxPartWidth, this.m_penisPartsInOrder[j].maxRadius);
			}
			this.m_worldMaxPartWidth *= 2f * this.m_worldScale;
			float num3 = this.puntaParte.maxWorldHeight * 0.666f;
			this.m_worldMaxWidthOrTipLength = Mathf.Max(num3, this.m_worldMaxPartWidth);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x000177C8 File Offset: 0x000159C8
		public Vector3 ProyectTo(Vector3 worldPosition, out IPeneParte proyectedToParte)
		{
			for (int i = this.partesEnOrden.Count - 1; i >= 0; i--)
			{
				PenisPart penisPart = this.partesEnOrden[i];
				Vector3 lastColliderBaseWorldPosition = penisPart.mainCollider.GetLastColliderBaseWorldPosition();
				Vector3 lastColliderTipWorldPosition = penisPart.mainCollider.GetLastColliderTipWorldPosition();
				Vector3 vector = Math3d.ProjectPointOnLine(lastColliderBaseWorldPosition, lastColliderTipWorldPosition - lastColliderBaseWorldPosition, worldPosition);
				if (Math3d.PointOnWhichSideOfLineSegment(lastColliderBaseWorldPosition, lastColliderTipWorldPosition, vector) == 0)
				{
					proyectedToParte = penisPart;
					return Math3d.ProjectPointOnLine(lastColliderBaseWorldPosition, (lastColliderTipWorldPosition - lastColliderBaseWorldPosition).normalized, worldPosition);
				}
			}
			proyectedToParte = null;
			return Math3d.ProjectPointOnLineSegment(this.@base.mainCollider.GetLastColliderBaseWorldPosition(), this.tipPhysics.position, worldPosition);
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0001786C File Offset: 0x00015A6C
		public void GetPuntaStartTipWorldPositions(float lengthBonusAPuntaMod, out Vector3 startWorldPosition, out Vector3 tipWorldPosition, out Vector3 tipForward)
		{
			PenisPointCollider complementoCollider = this.punta.complementoCollider;
			startWorldPosition = complementoCollider.GetLastColliderBaseWorldPosition();
			tipWorldPosition = complementoCollider.GetLastColliderTipWorldPosition();
			Vector3 vector = tipWorldPosition - startWorldPosition;
			if (lengthBonusAPuntaMod != 1f)
			{
				tipWorldPosition = startWorldPosition + vector * lengthBonusAPuntaMod;
			}
			tipForward = vector.normalized;
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x000178E0 File Offset: 0x00015AE0
		public int PuntaPenetration(Vector3 worldPoint, float lengthBonusAPuntaMod, out Vector3 tipEndWorldPosition, out Vector3 tipStartWorldPosition, out Vector3 proyectedWorldPoint, out float t, out IPeneParte puntaParte)
		{
			puntaParte = this.punta;
			Vector3 vector;
			this.GetPuntaStartTipWorldPositions(lengthBonusAPuntaMod, out tipStartWorldPosition, out tipEndWorldPosition, out vector);
			worldPoint = Math3d.ProjectPointOnLine(tipStartWorldPosition, tipEndWorldPosition - tipStartWorldPosition, worldPoint);
			int num = Math3d.PointOnWhichSideOfLineSegment(tipStartWorldPosition, tipEndWorldPosition, worldPoint);
			switch (num)
			{
			case 0:
				proyectedWorldPoint = Math3d.ProjectPointOnLine(tipStartWorldPosition, vector, worldPoint);
				t = MathfExtension.InverseLerp(tipEndWorldPosition, tipStartWorldPosition, proyectedWorldPoint);
				break;
			case 1:
				proyectedWorldPoint = tipStartWorldPosition;
				t = 1f;
				break;
			case 2:
				proyectedWorldPoint = tipEndWorldPosition;
				t = 0f;
				break;
			default:
				throw new ArgumentOutOfRangeException(num.ToString());
			}
			return num;
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x000179BC File Offset: 0x00015BBC
		private void UpdateErectionState()
		{
			bool flag = this.IsBlocked();
			float num = this.configuracion.erectionPositiveVelocity * Time.deltaTime;
			float num2 = Mathf.Lerp(this.configuracion.minErectionMod, 1f, this.m_CurrentErection / 100f);
			float num3 = this.moddedErectionTarget;
			if (this.m_flagToInstantHide || !this.m_CurrentErection.AlmostEqualV2(num3, 1E-45f) || flag != this.m_blocked)
			{
				this.m_blocked = flag;
				if (num3 < this.m_CurrentErection)
				{
					num = this.configuracion.erectionNegativeVelocity * Time.deltaTime;
				}
				if (this.m_flagToInstantHide || this.m_blocked)
				{
					num3 = (this.m_ErectionTarget = 0f);
					num = float.MaxValue;
				}
				this.m_flagToInstantHide = false;
				this.m_CurrentErection = Mathf.MoveTowards(this.m_CurrentErection, num3, num);
				num2 = Mathf.Lerp(this.configuracion.minErectionMod, 1f, this.m_CurrentErection / 100f);
				float num4 = Mathf.Lerp(this.configuracion.minErectionAnchoModV2, 1f, num2.OutPow(this.configuracion.erectionSizeOutPower));
				this.m_anchoErectionMod = num4;
				float num5 = Mathf.Lerp(this.configuracion.minErectionLargoModV2, 1f, num2.OutPow(this.configuracion.erectionSizeOutPower));
				this.m_largoErectionMod = num5;
				float num6 = Mathf.Lerp(-this.configuracion.angleOnGravityWhenSoft, this.m_penisLinearChain.angleAgaintsGravity, this.m_CurrentErection / 100f);
				this.m_penisLinearChain.SetAngleAgainsGravity(num6);
				this.m_defaultLocalRotation = this.penisLinearChain.puntoBaseTransform.localRotation;
				for (int i = 0; i < this.m_penisPartsInOrder.Count; i++)
				{
					this.m_penisPartsInOrder[i].physicBone.WakeUp();
				}
			}
			float num7 = Mathf.Lerp(this.configuracion.minErectionAngularModV2, 1f, num2.InPow(this.configuracion.erectionModificatorsInPower));
			float num8 = Mathf.Lerp(this.configuracion.minErectionZModV2, 1f, num2.InPow(this.configuracion.erectionModificatorsInPower));
			if (!this.m_CurrentErectionAngularMod.AlmostEqualV2(num7, 1E-45f) || !this.m_CurrentErectionZMod.AlmostEqualV2(num8, 1E-45f))
			{
				this.m_CurrentErectionAngularMod = Mathf.MoveTowards(this.m_CurrentErectionAngularMod, num7, num / 100f);
				this.m_CurrentErectionZMod = Mathf.MoveTowards(this.m_CurrentErectionZMod, num8, num / 100f);
				for (int j = 0; j < this.m_modificadoresDeEreccion.Count; j++)
				{
					ModificadorDeDriversDeJoint modificadorDeDriversDeJoint = this.m_modificadoresDeEreccion[j];
					float num9 = Mathf.InverseLerp(0f, (float)this.m_modificadoresDeEreccion.Count, (float)(j + 1));
					num9 = num9.OutPow(this.configuracion.minErectionJointModPower);
					float num10 = Mathf.Lerp(1f, this.m_CurrentErectionAngularMod, num9);
					float num11 = Mathf.Lerp(1f, this.m_CurrentErectionZMod, num9);
					modificadorDeDriversDeJoint.SetAllAngularTo(num10, true);
					modificadorDeDriversDeJoint.SetZTo(num11, true);
					modificadorDeDriversDeJoint.ForceFixOwner();
				}
			}
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x00017CE4 File Offset: 0x00015EE4
		private bool UpdateHiddeState()
		{
			if (this.isPenetrating)
			{
				return false;
			}
			if (this.hidden == this.m_HiddenLast)
			{
				return false;
			}
			this.m_HiddenLast = this.hidden;
			this.ChangeHiddenSateOfParts(this.m_HiddenLast);
			if (!this.hidden)
			{
				IHitSkinnedCharacter hitSkinnedCharacter = this.m_hitSkinnedCharacter;
				if (hitSkinnedCharacter != null)
				{
					hitSkinnedCharacter.ReIgnoreSkinSelfCollisions();
				}
			}
			return true;
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00017D40 File Offset: 0x00015F40
		public bool EsPuntaOrLastPart(Collider collider)
		{
			PenisPart penisPart = this.m_penisPartsInOrder[this.m_penisPartsInOrder.Count - 1];
			return penisPart.mainCollider.collidersSet.Contains(collider) || penisPart.complementoCollider.collidersSet.Contains(collider);
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00017D8C File Offset: 0x00015F8C
		public void GetColliders(List<Collider> todosResult)
		{
			this.GetColliders(todosResult, null);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x00017D98 File Offset: 0x00015F98
		public void GetColliders(List<Collider> todosResult, List<Collider> puntasResult)
		{
			for (int i = 0; i < this.m_penisPartsInOrder.Count; i++)
			{
				PenisPart penisPart = this.m_penisPartsInOrder[i];
				bool flag = i.IsLastIndex(this.m_penisPartsInOrder.Count);
				PenisPointCollider complementoCollider = penisPart.complementoCollider;
				bool flag2;
				if (complementoCollider == null)
				{
					flag2 = false;
				}
				else
				{
					IReadOnlyList<Collider> collidersV = complementoCollider.collidersV2;
					int? num = ((collidersV != null) ? new int?(collidersV.Count) : null);
					int num2 = 0;
					flag2 = (num.GetValueOrDefault() > num2) & (num != null);
				}
				if (flag2)
				{
					todosResult.AddRange(penisPart.complementoCollider.collidersV2);
					if (flag && puntasResult != null)
					{
						puntasResult.AddRange(penisPart.complementoCollider.collidersV2);
					}
				}
				PenisPointCollider mainCollider = penisPart.mainCollider;
				bool flag3;
				if (mainCollider == null)
				{
					flag3 = false;
				}
				else
				{
					IReadOnlyList<Collider> collidersV2 = mainCollider.collidersV2;
					int? num = ((collidersV2 != null) ? new int?(collidersV2.Count) : null);
					int num2 = 0;
					flag3 = (num.GetValueOrDefault() > num2) & (num != null);
				}
				if (flag3)
				{
					todosResult.AddRange(penisPart.mainCollider.collidersV2);
					if (flag && puntasResult != null)
					{
						puntasResult.AddRange(penisPart.mainCollider.collidersV2);
					}
				}
			}
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x00017EBC File Offset: 0x000160BC
		private void ChangeHiddenSateOfParts(bool hidden)
		{
			if (this.allRenderer != null)
			{
				for (int i = 0; i < this.allRenderer.Count; i++)
				{
					if (this.allRenderer[i] != null)
					{
						this.allRenderer[i].enabled = !hidden;
					}
				}
			}
			for (int j = 0; j < this.m_penisPartsInOrder.Count; j++)
			{
				this.m_penisPartsInOrder[j].hidden = hidden;
			}
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x00017F38 File Offset: 0x00016138
		public void FixPenisDirection()
		{
			Transform parent = this.penisLinearChain.puntoBaseTransform.parent;
			Transform puntoBaseTransform = this.penisLinearChain.puntoBaseTransform;
			Quaternion quaternion = parent.rotation * this.m_defaultLocalRotation;
			BoneStretchedChain boneStretchedChain;
			if (this.IsPenetratingHole(out boneStretchedChain))
			{
				Transform entrada = boneStretchedChain.entrada;
				Quaternion quaternion2 = Math3d.DampedTrackRotation(puntoBaseTransform, entrada, this.m_defaultLocalRotation, this.m_penisLinearChain.localForward, false);
				if (this.apuntarAHoleEnPenetracionMaxAngle < 360f)
				{
					quaternion2 = Quaternion.RotateTowards(quaternion, quaternion2, this.apuntarAHoleEnPenetracionMaxAngle);
				}
				this.PonitAt(quaternion2, this.apuntarVelocidadAlEntrar * Time.fixedDeltaTime);
				return;
			}
			if (ExtendedMonoBehaviour.AlmostEqual(this.m_defaultLocalRotation, this.penisLinearChain.puntoBaseTransform.localRotation, 0.1f))
			{
				return;
			}
			this.PonitAt(quaternion, this.apuntarVelocidadAlSalir * Time.fixedDeltaTime);
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00018006 File Offset: 0x00016206
		public void PonitAt(Quaternion targetRotation, float step)
		{
			Transform puntoBaseTransform = this.penisLinearChain.puntoBaseTransform;
			puntoBaseTransform.rotation = Quaternion.RotateTowards(puntoBaseTransform.rotation, targetRotation, step);
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x00018028 File Offset: 0x00016228
		private void AddPartes()
		{
			foreach (KeyValuePair<int, PenisPoint> keyValuePair in this.penisLinearChain.ObtenerPuntos())
			{
				int num = keyValuePair.Key + 1;
				PenisPoint value = keyValuePair.Value;
				Rigidbody connectedBody = value.joint.connectedBody;
				PenisPart penisPart;
				if (!value.isLast)
				{
					penisPart = connectedBody.GetComponentNotNull<PenisPart>();
				}
				else
				{
					penisPart = connectedBody.GetComponentNotNull<PenisPartPunta>();
				}
				Transform charBoneTarget = value.chain.GetCharBoneTarget(value.index + 1);
				penisPart.SetManualStart();
				penisPart.SetParam(this, num, value, charBoneTarget);
				penisPart.config = this.partesConfig;
				this.m_dicPointToPart.Add(value, penisPart);
				this.m_penisPartsInOrder.Add(penisPart);
			}
			this.m_penisPartsInOrder.Sort((PenisPart a, PenisPart b) => a.index.CompareTo(b.index));
			foreach (PenisPart penisPart2 in this.m_penisPartsInOrder)
			{
				penisPart2.ManualStart();
				penisPart2.complementoCollider.mainCollider.sharedMaterial = (penisPart2.mainCollider.mainCollider.sharedMaterial = this.m_PhysicMaterial);
			}
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x000181A8 File Offset: 0x000163A8
		private void UpdateCurrentDeep(Transform holeEntrada)
		{
			if (this.m_worldlargo == 0f)
			{
				Debug.LogError("Pene largo es zero", this);
			}
			float worldDistanceToHole = this.m_penisPartsInOrder[0].worldDistanceToHole;
			float num = ((worldDistanceToHole < 0f) ? this.m_worldLengthFromUnderSkin : worldDistanceToHole);
			num -= this.m_worldLengthUnderSkin;
			num = Mathf.Clamp(num, 0f, this.m_worldlargo);
			this.m_worldlargoInsideHole = this.m_worldlargo - num;
			this.m_worldlargoInsideHoleMod = Mathf.Clamp01(this.m_worldlargoInsideHole / this.m_worldlargo);
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00018232 File Offset: 0x00016432
		void IPenisPenetratiosCallbacks.TryingEnter(Penetraciones.TryPenetrationArgs args, Penetraciones penetracionesChecker)
		{
			IPeneCallbacksHandler peneCallbacksHandler = this.peneTryingEnterInHole;
			if (peneCallbacksHandler != null)
			{
				peneCallbacksHandler(penetracionesChecker.hole, this);
			}
			if (this.isPenetrating || this.m_blocked || this.m_CurrentErection < 66f)
			{
				args.DenyPenetration();
			}
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x00018270 File Offset: 0x00016470
		void IPenisPenetratiosCallbacks.OnEnter(Penetraciones penetracionesChecker)
		{
			this.UpdateCurrentDeep(penetracionesChecker.hole.entrada);
			IPeneCallbacksHandler peneCallbacksHandler = this.peneEnteredInHole;
			if (peneCallbacksHandler != null)
			{
				peneCallbacksHandler(penetracionesChecker.hole, this);
			}
			IPenePenetratingHandler penePenetratingHandler = this.entered;
			if (penePenetratingHandler == null)
			{
				return;
			}
			penePenetratingHandler(this, penetracionesChecker.hole);
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x000182C0 File Offset: 0x000164C0
		void IPenisPenetratiosCallbacks.OnStay(Penetraciones penetracionesChecker)
		{
			this.UpdateCurrentDeep(penetracionesChecker.hole.entrada);
			IPeneCallbacksHandler peneCallbacksHandler = this.peneStayedInHole;
			if (peneCallbacksHandler != null)
			{
				peneCallbacksHandler(penetracionesChecker.hole, this);
			}
			IPenePenetratingHandler penePenetratingHandler = this.stayed;
			if (penePenetratingHandler == null)
			{
				return;
			}
			penePenetratingHandler(this, penetracionesChecker.hole);
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x00018310 File Offset: 0x00016510
		void IPenisPenetratiosCallbacks.OnExit(Penetraciones penetracionesChecker)
		{
			this.m_worldlargoInsideHoleMod = 0f;
			this.m_worldlargoInsideHole = 0f;
			IPeneCallbacksHandler peneCallbacksHandler = this.peneExitedInHole;
			if (peneCallbacksHandler != null)
			{
				peneCallbacksHandler(penetracionesChecker.hole, this);
			}
			IPenePenetratingHandler penePenetratingHandler = this.exited;
			if (penePenetratingHandler == null)
			{
				return;
			}
			penePenetratingHandler(this, penetracionesChecker.hole);
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x00018362 File Offset: 0x00016562
		IHole IPene.TryGetPenetratingHole()
		{
			return this.TryGetPenetratingHole();
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0001836A File Offset: 0x0001656A
		IPenetrable IPeneSimple.TryGetPenetratingObject()
		{
			return this.TryGetPenetratingHole();
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x000184A9 File Offset: 0x000166A9
		bool IPene.get_isDestroyed()
		{
			return base.isDestroyed;
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x000184B1 File Offset: 0x000166B1
		bool IPene.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x000184B9 File Offset: 0x000166B9
		string IPene.get_name()
		{
			return base.name;
		}

		// Token: 0x0400041C RID: 1052
		public const float minErectionBeforeHide = 1f;

		// Token: 0x0400041D RID: 1053
		private List<Penetrador.HoleEntry> m_holesIntentando = new List<Penetrador.HoleEntry>(4);

		// Token: 0x0400041E RID: 1054
		public PenisPart.Config partesConfig = new PenisPart.Config();

		// Token: 0x04000426 RID: 1062
		[SerializeField]
		private GlobalUpdater.UpdateType m_UpdateEvent = GlobalUpdater.UpdateType.yieldFixedUpdate3;

		// Token: 0x04000427 RID: 1063
		[NonSerialized]
		private int m_layer;

		// Token: 0x04000428 RID: 1064
		public Quaternion userLocalRotation = Quaternion.identity;

		// Token: 0x04000429 RID: 1065
		private Quaternion m_defaultLocalRotation;

		// Token: 0x0400042A RID: 1066
		protected ICharacter m_inmediateOwner;

		// Token: 0x0400042B RID: 1067
		private IHitSkinnedCharacter m_hitSkinnedCharacter;

		// Token: 0x0400042C RID: 1068
		private PenisLinearChain m_penisLinearChain;

		// Token: 0x0400042D RID: 1069
		private Dictionary<PenisPoint, PenisPart> m_dicPointToPart = new Dictionary<PenisPoint, PenisPart>();

		// Token: 0x0400042E RID: 1070
		[ReadOnlyUI]
		[SerializeField]
		private List<PenisPart> m_penisPartsInOrder = new List<PenisPart>();

		// Token: 0x0400042F RID: 1071
		private PhysicMaterial m_PhysicMaterial;

		// Token: 0x04000430 RID: 1072
		public float currentAngleAgainsGravity;

		// Token: 0x04000431 RID: 1073
		[SerializeField]
		private ModificableDeFloat m_anguloContraGravedadAdder = new ModificableDeFloat(0f);

		// Token: 0x04000432 RID: 1074
		public float timeTryingToOpenHoleModificador = 1f;

		// Token: 0x04000433 RID: 1075
		[NonSerialized]
		private float m_lastAngleAgainsGravity;

		// Token: 0x04000434 RID: 1076
		public bool apuntarAHoleEnPenetracion = true;

		// Token: 0x04000435 RID: 1077
		public float apuntarVelocidadAlEntrar = 120f;

		// Token: 0x04000436 RID: 1078
		public float apuntarVelocidadAlSalir = 400f;

		// Token: 0x04000437 RID: 1079
		public float apuntarAHoleEnPenetracionMaxAngle = 360f;

		// Token: 0x04000438 RID: 1080
		[SerializeField]
		private List<ModificadorDeDriversDeJoint> m_modificadoresDeEreccion = new List<ModificadorDeDriversDeJoint>();

		// Token: 0x04000439 RID: 1081
		private ModificableDeFloat m_erectionModificable = new ModificableDeFloat(1f);

		// Token: 0x0400043A RID: 1082
		[SerializeField]
		private bool m_flagToInstantHide;

		// Token: 0x0400043B RID: 1083
		[ReadOnlyUI]
		[SerializeField]
		private bool m_blocked;

		// Token: 0x0400043C RID: 1084
		[Header("TODO: por ahora la escala debe ser linear, osea largo alterara tambien ancho")]
		[Range(0f, 10f)]
		[SerializeField]
		protected float m_largo = 1f;

		// Token: 0x0400043D RID: 1085
		private float m_largoErectionMod = 1f;

		// Token: 0x0400043E RID: 1086
		private float m_largoLast;

		// Token: 0x0400043F RID: 1087
		[Range(0f, 10f)]
		[SerializeField]
		protected float m_ancho = 1f;

		// Token: 0x04000440 RID: 1088
		private float m_anchoErectionMod = 1f;

		// Token: 0x04000441 RID: 1089
		private float m_anchoLast;

		// Token: 0x04000442 RID: 1090
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_rigidez = 1f;

		// Token: 0x04000443 RID: 1091
		private float m_rigidezLast;

		// Token: 0x04000444 RID: 1092
		[SerializeField]
		private ModificadorDeDriversDeJoint m_RigidezMod;

		// Token: 0x04000445 RID: 1093
		[ReadOnlyUI]
		[SerializeField]
		protected Transform m_skinSurfaceTransform;

		// Token: 0x04000446 RID: 1094
		[Range(0f, 100f)]
		[SerializeField]
		private float m_ErectionTarget;

		// Token: 0x04000447 RID: 1095
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldScale = 1f;

		// Token: 0x04000448 RID: 1096
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldLossyScale = 1f;

		// Token: 0x04000449 RID: 1097
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldlargo;

		// Token: 0x0400044A RID: 1098
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldLengthFromUnderSkin;

		// Token: 0x0400044B RID: 1099
		[ReadOnlyUI]
		[SerializeField]
		private float m_realCurrentWorldLengthFromUnderSkin;

		// Token: 0x0400044C RID: 1100
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldLengthUnderSkin;

		// Token: 0x0400044D RID: 1101
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldTipPartlargo;

		// Token: 0x0400044E RID: 1102
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldTipPartAncho;

		// Token: 0x0400044F RID: 1103
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldMaxPartWidth;

		// Token: 0x04000450 RID: 1104
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldMaxWidthOrTipLength;

		// Token: 0x04000451 RID: 1105
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldlargoInsideHole;

		// Token: 0x04000452 RID: 1106
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldlargoInsideHoleMod;

		// Token: 0x04000453 RID: 1107
		private float m_CurrentErection = 100f;

		// Token: 0x04000454 RID: 1108
		private float m_CurrentErectionAngularMod = 1f;

		// Token: 0x04000455 RID: 1109
		private float m_CurrentErectionZMod = 1f;

		// Token: 0x04000456 RID: 1110
		[SerializeField]
		private bool m_flagUpdateSize;

		// Token: 0x04000457 RID: 1111
		private bool m_HiddenLast;

		// Token: 0x04000458 RID: 1112
		private Dictionary<int, Tuple<TrasnformCopier, ModificadorDeFloat, ModificadorDeFloat>> m_modificadoresDeAnchoDePenePorIndex = new Dictionary<int, Tuple<TrasnformCopier, ModificadorDeFloat, ModificadorDeFloat>>();

		// Token: 0x04000459 RID: 1113
		public Penetrador.Configuracion configuracion = new Penetrador.Configuracion();

		// Token: 0x020001A7 RID: 423
		private class HoleEntry
		{
			// Token: 0x04000991 RID: 2449
			public WeakReference<IHole> hole;

			// Token: 0x04000992 RID: 2450
			public float distance;

			// Token: 0x04000993 RID: 2451
			public int frameID;
		}

		// Token: 0x020001A8 RID: 424
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000994 RID: 2452
			public float erectionPositiveVelocity = 30f;

			// Token: 0x04000995 RID: 2453
			public float erectionNegativeVelocity = 10f;

			// Token: 0x04000996 RID: 2454
			public float minErectionMod = 0.1f;

			// Token: 0x04000997 RID: 2455
			public float erectionModificatorsInPower = 20f;

			// Token: 0x04000998 RID: 2456
			public float erectionSizeOutPower = 3f;

			// Token: 0x04000999 RID: 2457
			public float minErectionAnchoModV2 = 0.666f;

			// Token: 0x0400099A RID: 2458
			public float minErectionLargoModV2 = 0.666f;

			// Token: 0x0400099B RID: 2459
			public float minErectionAngularModV2 = 0.01f;

			// Token: 0x0400099C RID: 2460
			public float minErectionZModV2 = 0.1f;

			// Token: 0x0400099D RID: 2461
			public float minErectionJointModPower = 15f;

			// Token: 0x0400099E RID: 2462
			public float angleOnGravityWhenSoft = 10f;
		}
	}
}
