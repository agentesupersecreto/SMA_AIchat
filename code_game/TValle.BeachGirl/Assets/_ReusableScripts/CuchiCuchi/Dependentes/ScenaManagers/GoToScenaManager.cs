using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using InterfaceFields;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers
{
	// Token: 0x0200011F RID: 287
	public class GoToScenaManager : Singleton<GoToScenaManager>
	{
		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06000C5E RID: 3166 RVA: 0x0002A1A5 File Offset: 0x000283A5
		public INombrableLocalizado turnAroundNombrable
		{
			get
			{
				return this.m_turnAroundNombrable as INombrableLocalizado;
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06000C5F RID: 3167 RVA: 0x0002A1B2 File Offset: 0x000283B2
		public IReadOnlyList<GoToScenaManager.GoTo> registrados
		{
			get
			{
				return this.m_Registrados;
			}
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x0002A1BA File Offset: 0x000283BA
		protected override void DoAwake()
		{
			base.DoAwake();
			if (this.turnAroundNombrable == null)
			{
				throw new ArgumentNullException("turnAroundNombrable", "turnAroundNombrable null reference.");
			}
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x0002A1DA File Offset: 0x000283DA
		protected override void InitData(bool esEditorTime)
		{
			if (!esEditorTime)
			{
				this.Init();
			}
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x0002A1E5 File Offset: 0x000283E5
		protected override void OnDestroyed(bool wasInitiated)
		{
			base.OnDestroyed(wasInitiated);
			this.Clear();
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x0002A1F4 File Offset: 0x000283F4
		public bool IsOn(string gotoID, Vector3 onPosition, Quaternion onOrientation, bool isTurnedAround, float positionPrecision = 0.4f, float anglePrecision = 45f, bool ignorarAltura = false)
		{
			GoToScenaManager.GoTo goTo = this.Obtener(gotoID);
			if (goTo == null)
			{
				return false;
			}
			Transform transform = goTo.transform;
			if (transform == null)
			{
				return false;
			}
			Vector3 position = transform.position;
			if (ignorarAltura)
			{
				position.y = 0f;
				onPosition.y = 0f;
			}
			if (!ExtendedMonoBehaviour.AlmostEqual(position, onPosition, positionPrecision))
			{
				return false;
			}
			Quaternion rotation = transform.rotation;
			float num;
			if (!isTurnedAround)
			{
				num = Quaternion.Angle(rotation, onOrientation);
			}
			else
			{
				num = Quaternion.Angle(GoToScenaManager.TurnedAroundRotation(rotation), onOrientation);
			}
			return num <= anglePrecision;
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x0002A280 File Offset: 0x00028480
		public bool IsOn(GoToScenaManager.GoTo gotoTarget, Vector3 onPosition, Quaternion onOrientation, bool isTurnedAround, float positionPrecision = 0.4f, float anglePrecision = 45f)
		{
			if (gotoTarget == null)
			{
				return false;
			}
			Transform transform = gotoTarget.transform;
			if (transform == null)
			{
				return false;
			}
			if (!ExtendedMonoBehaviour.AlmostEqual(transform.position, onPosition, positionPrecision))
			{
				return false;
			}
			Quaternion rotation = transform.rotation;
			float num;
			if (!isTurnedAround)
			{
				num = Quaternion.Angle(rotation, onOrientation);
			}
			else
			{
				num = Quaternion.Angle(GoToScenaManager.TurnedAroundRotation(rotation), onOrientation);
			}
			return num <= anglePrecision;
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x0002A2E0 File Offset: 0x000284E0
		public GoToScenaManager.GoTo CurrentGoTo(Transform target, out bool isTurnedAround, float positionPrecision = 0.4f, float anglePrecision = 45f)
		{
			for (int i = 0; i < this.m_Registrados.Count; i++)
			{
				isTurnedAround = false;
				GoToScenaManager.GoTo goTo = this.m_Registrados[i];
				Transform transform = ((goTo != null) ? goTo.transform : null);
				if (!(transform == null) && ExtendedMonoBehaviour.AlmostEqual(transform.position, target.position, positionPrecision))
				{
					Quaternion rotation = transform.rotation;
					float num = Quaternion.Angle(rotation, target.rotation);
					bool canTurnAround = goTo.canTurnAround;
					if (num <= anglePrecision)
					{
						return goTo;
					}
					if (canTurnAround)
					{
						isTurnedAround = true;
						if (Quaternion.Angle(GoToScenaManager.TurnedAroundRotation(rotation), target.rotation) <= anglePrecision)
						{
							return goTo;
						}
					}
				}
			}
			isTurnedAround = false;
			return null;
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x0002A390 File Offset: 0x00028590
		[Obsolete]
		public void Apply(Transform target, bool isTurnedAround, GoToScenaManager.GoTo goTo)
		{
			isTurnedAround = isTurnedAround && goTo.canTurnAround;
			if (!isTurnedAround)
			{
				target.SetPositionAndRotation(goTo.transform.position, goTo.transform.rotation);
				return;
			}
			target.SetPositionAndRotation(goTo.transform.position, GoToScenaManager.TurnedAroundRotation(goTo.transform.rotation));
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x0002A3EC File Offset: 0x000285EC
		[Obsolete]
		public void Apply(Action<Vector3, Quaternion> targetDelegate, bool isTurnedAround, GoToScenaManager.GoTo goTo)
		{
			isTurnedAround = isTurnedAround && goTo.canTurnAround;
			if (!isTurnedAround)
			{
				targetDelegate(goTo.transform.position, goTo.transform.rotation);
				return;
			}
			targetDelegate(goTo.transform.position, GoToScenaManager.TurnedAroundRotation(goTo.transform.rotation));
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x0002A448 File Offset: 0x00028648
		public void Apply(ICharacterTeleportable character, bool isTurnedAround, GoToScenaManager.GoTo goTo)
		{
			if (goTo != null)
			{
				goTo.CallOnUsing(null, character, character.self);
			}
			isTurnedAround = isTurnedAround && goTo.canTurnAround;
			if (!isTurnedAround)
			{
				character.SetPositionAndRotation(goTo.transform.position, goTo.transform.rotation);
				return;
			}
			character.SetPositionAndRotation(goTo.transform.position, GoToScenaManager.TurnedAroundRotation(goTo.transform.rotation));
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x0002A4B8 File Offset: 0x000286B8
		public void NavTo(ICharacterNavegable character, bool isTurnedAround, GoToScenaManager.GoTo goTo, float maxMagnitude, float cornerDistanceMod, bool OnlyStrafe)
		{
			if (goTo != null)
			{
				goTo.CallOnUsing(character, null, character.self);
			}
			Quaternion quaternion = ((!isTurnedAround) ? goTo.transform.rotation : GoToScenaManager.TurnedAroundRotation(goTo.transform.rotation));
			character.NavToTarget(goTo.transform, true, maxMagnitude, cornerDistanceMod, OnlyStrafe, new Vector3?(quaternion * Vector3.forward), null, null);
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x0002A51C File Offset: 0x0002871C
		private static Quaternion TurnedAroundRotation(Quaternion original)
		{
			return original * Quaternion.AngleAxis(180f, Vector3.up);
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x0002A533 File Offset: 0x00028733
		private void add(GoToScenaManager.GoTo item)
		{
			this.m_porID.Add(item.Id, item);
			this.m_porTransform.Add(item.transform, item);
			this.m_Registrados.Add(item);
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x0002A568 File Offset: 0x00028768
		public void Add(GoToScenaManager.GoTo item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item", "item null reference.");
			}
			if (!item.isValid)
			{
				throw new InvalidOperationException();
			}
			if (this.m_porID.ContainsKey(item.Id))
			{
				throw new InvalidOperationException();
			}
			if (this.m_porTransform.ContainsKey(item.transform))
			{
				throw new InvalidOperationException();
			}
			this.add(item);
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x0002A5D0 File Offset: 0x000287D0
		public bool TryAdd(GoToScenaManager.GoTo item)
		{
			if (item == null)
			{
				return false;
			}
			if (!item.isValid)
			{
				return false;
			}
			if (this.m_porID.ContainsKey(item.Id))
			{
				return true;
			}
			if (this.m_porTransform.ContainsKey(item.transform))
			{
				return false;
			}
			this.add(item);
			return true;
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x0002A620 File Offset: 0x00028820
		public bool Remove(GoToScenaManager.GoTo item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item", "item null reference.");
			}
			this.m_Registrados.Remove(item);
			return this.m_porID.Remove(item.Id) || this.m_porTransform.Remove(item.transform);
		}

		// Token: 0x06000C6F RID: 3183 RVA: 0x0002A674 File Offset: 0x00028874
		public bool Remove(Transform item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item", "item null reference.");
			}
			GoToScenaManager.GoTo goTo = this.Obtener(item);
			return goTo != null && this.Remove(goTo);
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x0002A6B0 File Offset: 0x000288B0
		public bool Remove(string id)
		{
			GoToScenaManager.GoTo goTo = this.Obtener(id);
			return goTo != null && this.Remove(goTo);
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x0002A6D1 File Offset: 0x000288D1
		public bool Contiene(string id)
		{
			return this.Obtener(id) != null;
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x0002A6DD File Offset: 0x000288DD
		public bool Contiene(Transform trans)
		{
			return this.Obtener(trans) != null;
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x0002A6EC File Offset: 0x000288EC
		public GoToScenaManager.GoTo Obtener(string id)
		{
			GoToScenaManager.GoTo goTo;
			if (!this.m_porID.TryGetValue(id, out goTo))
			{
				return null;
			}
			return goTo;
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x0002A70C File Offset: 0x0002890C
		public GoToScenaManager.GoTo Obtener(Transform trans)
		{
			GoToScenaManager.GoTo goTo;
			if (!this.m_porTransform.TryGetValue(trans, out goTo))
			{
				return null;
			}
			return goTo;
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x0002A72C File Offset: 0x0002892C
		private void Init()
		{
			this.m_porID = new Dictionary<string, GoToScenaManager.GoTo>();
			this.m_porTransform = new Dictionary<Transform, GoToScenaManager.GoTo>();
			this.m_Registrados = new List<GoToScenaManager.GoTo>();
			foreach (GoToScenaManager.GoTo goTo in this.m_paraRegistrarEditorTime)
			{
				if (!goTo.isValid)
				{
					Debug.LogError("Item no es valido, se ignorara.", this);
				}
				else if (this.m_porID.ContainsKey(goTo.Id))
				{
					Debug.LogError("ID " + goTo.Id + " esta duplicada, se ignorara item.", this);
				}
				else if (this.m_porTransform.ContainsKey(goTo.transform))
				{
					Debug.LogError("Transform " + goTo.transform.name + " esta duplicado, se ignorara item.", this);
				}
				else
				{
					this.add(goTo);
				}
			}
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x0002A820 File Offset: 0x00028A20
		private void Clear()
		{
			Dictionary<string, GoToScenaManager.GoTo> porID = this.m_porID;
			if (porID != null)
			{
				porID.Clear();
			}
			Dictionary<Transform, GoToScenaManager.GoTo> porTransform = this.m_porTransform;
			if (porTransform != null)
			{
				porTransform.Clear();
			}
			List<GoToScenaManager.GoTo> registrados = this.m_Registrados;
			if (registrados == null)
			{
				return;
			}
			registrados.Clear();
		}

		// Token: 0x040006AA RID: 1706
		[ConstraintType(typeof(INombrableLocalizado))]
		[SerializeField]
		private Object m_turnAroundNombrable;

		// Token: 0x040006AB RID: 1707
		[CoolArrayItem]
		[SerializeField]
		private List<GoToScenaManager.GoTo> m_paraRegistrarEditorTime = new List<GoToScenaManager.GoTo>();

		// Token: 0x040006AC RID: 1708
		private Dictionary<string, GoToScenaManager.GoTo> m_porID;

		// Token: 0x040006AD RID: 1709
		private Dictionary<Transform, GoToScenaManager.GoTo> m_porTransform;

		// Token: 0x040006AE RID: 1710
		[ReadOnlyUI]
		[SerializeField]
		private List<GoToScenaManager.GoTo> m_Registrados;

		// Token: 0x040006AF RID: 1711
		public const float defaultPositionPrecision = 0.4f;

		// Token: 0x040006B0 RID: 1712
		public const float defaultAnglePrecision = 45f;

		// Token: 0x020001FD RID: 509
		public enum Orientacion
		{
			// Token: 0x04000AF2 RID: 2802
			@default,
			// Token: 0x04000AF3 RID: 2803
			turnedAround,
			// Token: 0x04000AF4 RID: 2804
			lookingLeft,
			// Token: 0x04000AF5 RID: 2805
			lookingRight
		}

		// Token: 0x020001FE RID: 510
		[Serializable]
		public class GoTo
		{
			// Token: 0x06000FDE RID: 4062 RVA: 0x0003544C File Offset: 0x0003364C
			public GoTo(string Id, Transform trans, INombrableLocalizado nom, bool CanTurnAround, GoToScenaManager.GoTo.OnUsingHandler OnUsing)
			{
				if (nom == null)
				{
					throw new ArgumentNullException("nom", "nom null reference.");
				}
				if (trans == null)
				{
					throw new ArgumentNullException("trans", "trans null reference.");
				}
				this.onUsing -= OnUsing;
				this.onUsing += OnUsing;
				this.m_transform = trans;
				this.m_nombrableObj = (Object)nom;
				this.m_id = Id;
				this.m_canTurnAround = CanTurnAround;
			}

			// Token: 0x17000535 RID: 1333
			// (get) Token: 0x06000FDF RID: 4063 RVA: 0x000354BD File Offset: 0x000336BD
			public bool isValid
			{
				get
				{
					return !string.IsNullOrWhiteSpace(this.m_id) && this.m_transform != null && this.nombrable != null;
				}
			}

			// Token: 0x14000062 RID: 98
			// (add) Token: 0x06000FE0 RID: 4064 RVA: 0x000354E8 File Offset: 0x000336E8
			// (remove) Token: 0x06000FE1 RID: 4065 RVA: 0x00035520 File Offset: 0x00033720
			public event GoToScenaManager.GoTo.OnUsingHandler onUsing;

			// Token: 0x06000FE2 RID: 4066 RVA: 0x00035555 File Offset: 0x00033755
			internal void CallOnUsing(ICharacterNavegable navegable, ICharacterTeleportable teleportable, ICharacter character)
			{
				GoToScenaManager.GoTo.OnUsingHandler onUsingHandler = this.onUsing;
				if (onUsingHandler == null)
				{
					return;
				}
				onUsingHandler(navegable, teleportable, character, this);
			}

			// Token: 0x06000FE3 RID: 4067 RVA: 0x0003556B File Offset: 0x0003376B
			public void SetTrasform(Transform trans)
			{
				this.m_transform = trans;
			}

			// Token: 0x17000536 RID: 1334
			// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x00035574 File Offset: 0x00033774
			public Transform transform
			{
				get
				{
					return this.m_transform;
				}
			}

			// Token: 0x17000537 RID: 1335
			// (get) Token: 0x06000FE5 RID: 4069 RVA: 0x0003557C File Offset: 0x0003377C
			public INombrableLocalizado nombrable
			{
				get
				{
					return this.m_nombrableObj as INombrableLocalizado;
				}
			}

			// Token: 0x17000538 RID: 1336
			// (get) Token: 0x06000FE6 RID: 4070 RVA: 0x00035589 File Offset: 0x00033789
			public string Id
			{
				get
				{
					return this.m_id;
				}
			}

			// Token: 0x17000539 RID: 1337
			// (get) Token: 0x06000FE7 RID: 4071 RVA: 0x00035591 File Offset: 0x00033791
			public string Type
			{
				get
				{
					return this.m_id;
				}
			}

			// Token: 0x1700053A RID: 1338
			// (get) Token: 0x06000FE8 RID: 4072 RVA: 0x00035599 File Offset: 0x00033799
			public bool esDefault
			{
				get
				{
					return this.m_esDefault;
				}
			}

			// Token: 0x1700053B RID: 1339
			// (get) Token: 0x06000FE9 RID: 4073 RVA: 0x000355A1 File Offset: 0x000337A1
			public bool canTurnAround
			{
				get
				{
					return this.m_canTurnAround;
				}
			}

			// Token: 0x1700053C RID: 1340
			// (get) Token: 0x06000FEA RID: 4074 RVA: 0x000355A9 File Offset: 0x000337A9
			public bool hidden
			{
				get
				{
					return this.m_hidden;
				}
			}

			// Token: 0x04000AF6 RID: 2806
			[SerializeField]
			private string m_id;

			// Token: 0x04000AF7 RID: 2807
			[SerializeField]
			private bool m_canTurnAround;

			// Token: 0x04000AF8 RID: 2808
			[SerializeField]
			private bool m_esDefault;

			// Token: 0x04000AF9 RID: 2809
			[SerializeField]
			private bool m_hidden;

			// Token: 0x04000AFA RID: 2810
			[SerializeField]
			private Transform m_transform;

			// Token: 0x04000AFB RID: 2811
			[ConstraintType(typeof(INombrableLocalizado))]
			[SerializeField]
			private Object m_nombrableObj;

			// Token: 0x02000260 RID: 608
			// (Invoke) Token: 0x06001092 RID: 4242
			public delegate void OnUsingHandler(ICharacterNavegable navegable, ICharacterTeleportable teleportable, ICharacter character, GoToScenaManager.GoTo sender);
		}
	}
}
