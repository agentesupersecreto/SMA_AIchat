using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Base.BeachGirl.Controladores.Materiales.Test.Runtime.Scripts
{
	// Token: 0x020000CA RID: 202
	public class CharactererDummy : CustomMonobehaviour, ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060004E4 RID: 1252 RVA: 0x00018BEC File Offset: 0x00016DEC
		ICharacter ICharacterTeleportable.self
		{
			get
			{
				return this;
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00018BF0 File Offset: 0x00016DF0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			foreach (Renderer renderer in base.GetComponentsInChildren<Renderer>())
			{
				List<Material> list = new List<Material>();
				Material[] sharedMaterials = renderer.sharedMaterials;
				for (int j = 0; j < sharedMaterials.Length; j++)
				{
					Material material = Object.Instantiate<Material>(sharedMaterials[j]);
					material.name = material.name.Replace("(Clone)", "");
					list.Add(material);
				}
				this.clonnedMAts.AddRange(list);
				renderer.sharedMaterials = list.ToArray();
			}
			this.LoadApareienciaFisica();
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00018C8C File Offset: 0x00016E8C
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

		// Token: 0x060004E7 RID: 1255 RVA: 0x00018CEC File Offset: 0x00016EEC
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			foreach (Material material in this.clonnedMAts)
			{
				Object.Destroy(material);
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x00018D44 File Offset: 0x00016F44
		public Sexo sexo
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x00018D4B File Offset: 0x00016F4B
		public bool isAlive
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x00018D52 File Offset: 0x00016F52
		public float escala
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x00018D5C File Offset: 0x00016F5C
		public Vector3 worldFirstPersonViewPoint
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x00018D6E File Offset: 0x00016F6E
		public Transform animatorRootMotionTransform
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x00018D75 File Offset: 0x00016F75
		public Transform rootBoneTransform
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x00018D7C File Offset: 0x00016F7C
		public Vector3 posicion
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x00018D90 File Offset: 0x00016F90
		public Quaternion rotacion
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x00018DA2 File Offset: 0x00016FA2
		public bool memoryApareienciaFisicaLoaded
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x00018DA9 File Offset: 0x00016FA9
		public bool apareienciaFisicaLoaded
		{
			get
			{
				return this.m_apareienciaFisicaLoaded;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x00018DB1 File Offset: 0x00016FB1
		public Animator bodyAnimator
		{
			get
			{
				return base.GetComponentInChildren<Animator>();
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x00018DBC File Offset: 0x00016FBC
		public Vector3 worldHeadPosition
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x00018DCE File Offset: 0x00016FCE
		public Transform hips
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x00018DD8 File Offset: 0x00016FD8
		public Vector3 centerOfMassUpDirection
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x00018DEC File Offset: 0x00016FEC
		public Vector3 centerOfMassForwardDirection
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x00018E00 File Offset: 0x00017000
		public Vector3 centerOfMassRightDirection
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x00018E12 File Offset: 0x00017012
		public ICharacter master
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x00018E19 File Offset: 0x00017019
		public float estatura
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x00018E20 File Offset: 0x00017020
		public string nombreCompleto
		{
			get
			{
				return base.name;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x00018E28 File Offset: 0x00017028
		public string nombre
		{
			get
			{
				return base.name;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x00018E30 File Offset: 0x00017030
		public string apellido
		{
			get
			{
				return base.name;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x00018E38 File Offset: 0x00017038
		public Vector3 centerOfMassPosition
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x00018E4C File Offset: 0x0001704C
		public Quaternion centerOfMassRotation
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x00018E5E File Offset: 0x0001705E
		public Transform trasnformParaComunicarse
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x00018E68 File Offset: 0x00017068
		public Vector3 centerOfMassVelocity
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x00018E7A File Offset: 0x0001707A
		public bool loaded
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x00018E7D File Offset: 0x0001707D
		public float defaultEstatura
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x00018E84 File Offset: 0x00017084
		public float defaultHandWidth
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x00018E8B File Offset: 0x0001708B
		public float defaultHandHeight
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x06000505 RID: 1285 RVA: 0x00018E94 File Offset: 0x00017094
		// (remove) Token: 0x06000506 RID: 1286 RVA: 0x00018ECC File Offset: 0x000170CC
		public event Action<ICharacter> loadingApareienciaFisica;

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x06000507 RID: 1287 RVA: 0x00018F04 File Offset: 0x00017104
		// (remove) Token: 0x06000508 RID: 1288 RVA: 0x00018F3C File Offset: 0x0001713C
		public event Action<ICharacter> onLoadApareienciaFisica;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x06000509 RID: 1289 RVA: 0x00018F74 File Offset: 0x00017174
		// (remove) Token: 0x0600050A RID: 1290 RVA: 0x00018FAC File Offset: 0x000171AC
		public event Action<ICharacter> loadedApareienciaFisica;

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x0600050B RID: 1291 RVA: 0x00018FE4 File Offset: 0x000171E4
		// (remove) Token: 0x0600050C RID: 1292 RVA: 0x0001901C File Offset: 0x0001721C
		public event Action<ICharacter> memoryLoadingApareienciaFisica;

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x0600050D RID: 1293 RVA: 0x00019054 File Offset: 0x00017254
		// (remove) Token: 0x0600050E RID: 1294 RVA: 0x0001908C File Offset: 0x0001728C
		public event Action<ICharacter> memoryOnLoadApareienciaFisica;

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x0600050F RID: 1295 RVA: 0x000190C4 File Offset: 0x000172C4
		// (remove) Token: 0x06000510 RID: 1296 RVA: 0x000190FC File Offset: 0x000172FC
		public event Action<ICharacter> memoryLoadedApareienciaFisica;

		// Token: 0x06000511 RID: 1297 RVA: 0x00019131 File Offset: 0x00017331
		public T GetComponentEnRoot<T>()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x00019138 File Offset: 0x00017338
		public void IgnorarCollosionesConMano(IReadOnlyList<Collider> others, Side side, bool ignore)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0001913F File Offset: 0x0001733F
		public void IgnorarCollosionesConMano(IList<Collider> others, Side side, bool ignore)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00019146 File Offset: 0x00017346
		public void IgnorarCollosionesConMano(Collider other, Side side, bool ignore)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0001914D File Offset: 0x0001734D
		public void IgnorarCollosionesConManos(IReadOnlyList<Collider> others, bool ignore)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00019154 File Offset: 0x00017354
		public void IgnorarCollosionesConManos(IList<Collider> others, bool ignore)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0001915B File Offset: 0x0001735B
		public void IgnorarCollosionesConManos(Collider other, bool ignore)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00019162 File Offset: 0x00017362
		public bool ObjetoEsMiAnteBrazo(Transform obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00019169 File Offset: 0x00017369
		public bool ObjetoEsMiMano(Collider obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00019170 File Offset: 0x00017370
		public bool ObjetoEsMiMano(Rigidbody obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00019177 File Offset: 0x00017377
		public bool ObjetoEsMiMano(Transform obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0001917E File Offset: 0x0001737E
		public bool ObjetoEsMiPene(Collider obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x00019185 File Offset: 0x00017385
		public bool ObjetoEsMiPene(Rigidbody obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0001918C File Offset: 0x0001738C
		public bool ObjetoEsMiPene(Transform obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00019193 File Offset: 0x00017393
		public bool ObjetoEsMiPierna(Collider obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0001919A File Offset: 0x0001739A
		public bool ObjetoEsMiPierna(Rigidbody obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x000191A1 File Offset: 0x000173A1
		public bool ObjetoEsMiPierna(Transform obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x000191A8 File Offset: 0x000173A8
		public bool ObjetoEsMiTorzo(Collider obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x000191AF File Offset: 0x000173AF
		public bool ObjetoEsMiTorzo(Rigidbody obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x000191B6 File Offset: 0x000173B6
		public bool ObjetoEsMiTorzo(Transform obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x000191BD File Offset: 0x000173BD
		public bool ObjetoEsProp(Transform obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x000191C4 File Offset: 0x000173C4
		public bool ObjetoMePertenece(Transform obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x000191CB File Offset: 0x000173CB
		public void SetPositionAndRotation(Transform targetTransform)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x000191D2 File Offset: 0x000173D2
		public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x000191D9 File Offset: 0x000173D9
		public bool ObjetoEsMiDedo(Collider obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x000191E0 File Offset: 0x000173E0
		public bool ObjetoEsMiDedo(Rigidbody obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x000191E7 File Offset: 0x000173E7
		public bool ObjetoEsMiDedo(Transform obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x000191EE File Offset: 0x000173EE
		public bool ObjetoEsMiPene(Component obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x000191F5 File Offset: 0x000173F5
		public bool ObjetoEsMiDedo(Component obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x000191FC File Offset: 0x000173FC
		public T GetComponentNotNull<T>() where T : Component
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0001921D File Offset: 0x0001741D
		Transform ICharacterRoot.get_transform()
		{
			return base.transform;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00019225 File Offset: 0x00017425
		T ICharacterRoot.GetComponentInChildren<T>()
		{
			return base.GetComponentInChildren<T>();
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0001922D File Offset: 0x0001742D
		T ICharacterRoot.GetComponentInParent<T>()
		{
			return base.GetComponentInParent<T>();
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00019235 File Offset: 0x00017435
		T ICharacterRoot.GetComponentInParent<T>(bool includeInactive)
		{
			return base.GetComponentInParent<T>(includeInactive);
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0001923E File Offset: 0x0001743E
		T ICharacterRoot.GetComponentInChildren<T>(bool includeInactive)
		{
			return base.GetComponentInChildren<T>(includeInactive);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00019247 File Offset: 0x00017447
		T ICharacterRoot.GetComponent<T>()
		{
			return base.GetComponent<T>();
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0001924F File Offset: 0x0001744F
		void ICharacterRoot.GetComponentsInChildren<T>(List<T> results)
		{
			base.GetComponentsInChildren<T>(results);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00019258 File Offset: 0x00017458
		void ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive, List<T> result)
		{
			base.GetComponentsInChildren<T>(includeInactive, result);
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00019262 File Offset: 0x00017462
		T[] ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive)
		{
			return base.GetComponentsInChildren<T>(includeInactive);
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0001926B File Offset: 0x0001746B
		Coroutine ICharacterRoot.StartCoroutine(IEnumerator routine)
		{
			return base.StartCoroutine(routine);
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00019274 File Offset: 0x00017474
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0001927C File Offset: 0x0001747C
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400023E RID: 574
		private List<Material> clonnedMAts = new List<Material>();

		// Token: 0x0400023F RID: 575
		private bool m_apareienciaFisicaLoaded = true;
	}
}
