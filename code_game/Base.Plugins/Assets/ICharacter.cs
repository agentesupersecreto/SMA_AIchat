using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000B8 RID: 184
	public interface ICharacter : ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable
	{
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000553 RID: 1363
		ICharacter master { get; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000554 RID: 1364
		Sexo sexo { get; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000555 RID: 1365
		string nombreCompleto { get; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000556 RID: 1366
		string nombre { get; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000557 RID: 1367
		string apellido { get; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000558 RID: 1368
		bool isAlive { get; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000559 RID: 1369
		float escala { get; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600055A RID: 1370
		float estatura { get; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600055B RID: 1371
		float defaultEstatura { get; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600055C RID: 1372
		float defaultHandWidth { get; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600055D RID: 1373
		float defaultHandHeight { get; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600055E RID: 1374
		Vector3 worldHeadPosition { get; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600055F RID: 1375
		Vector3 worldFirstPersonViewPoint { get; }

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000560 RID: 1376
		Transform animatorRootMotionTransform { get; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000561 RID: 1377
		Transform rootBoneTransform { get; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000562 RID: 1378
		Transform hips { get; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000563 RID: 1379
		Transform trasnformParaComunicarse { get; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000564 RID: 1380
		Vector3 posicion { get; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000565 RID: 1381
		Quaternion rotacion { get; }

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000566 RID: 1382
		// (remove) Token: 0x06000567 RID: 1383
		event Action<ICharacter> loadingApareienciaFisica;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000568 RID: 1384
		// (remove) Token: 0x06000569 RID: 1385
		event Action<ICharacter> onLoadApareienciaFisica;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600056A RID: 1386
		// (remove) Token: 0x0600056B RID: 1387
		event Action<ICharacter> loadedApareienciaFisica;

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600056C RID: 1388
		bool loaded { get; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600056D RID: 1389
		bool memoryApareienciaFisicaLoaded { get; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600056E RID: 1390
		bool apareienciaFisicaLoaded { get; }

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600056F RID: 1391
		// (remove) Token: 0x06000570 RID: 1392
		event Action<ICharacter> memoryLoadingApareienciaFisica;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000571 RID: 1393
		// (remove) Token: 0x06000572 RID: 1394
		event Action<ICharacter> memoryOnLoadApareienciaFisica;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000573 RID: 1395
		// (remove) Token: 0x06000574 RID: 1396
		event Action<ICharacter> memoryLoadedApareienciaFisica;

		// Token: 0x06000575 RID: 1397
		bool ObjetoEsProp(Transform obj);

		// Token: 0x06000576 RID: 1398
		bool ObjetoMePertenece(Transform obj);

		// Token: 0x06000577 RID: 1399
		bool ObjetoEsMiPierna(Collider obj);

		// Token: 0x06000578 RID: 1400
		bool ObjetoEsMiPierna(Rigidbody obj);

		// Token: 0x06000579 RID: 1401
		bool ObjetoEsMiPierna(Transform obj);

		// Token: 0x0600057A RID: 1402
		bool ObjetoEsMiTorzo(Collider obj);

		// Token: 0x0600057B RID: 1403
		bool ObjetoEsMiTorzo(Rigidbody obj);

		// Token: 0x0600057C RID: 1404
		bool ObjetoEsMiTorzo(Transform obj);

		// Token: 0x0600057D RID: 1405
		bool ObjetoEsMiPene(Collider obj);

		// Token: 0x0600057E RID: 1406
		bool ObjetoEsMiPene(Rigidbody obj);

		// Token: 0x0600057F RID: 1407
		bool ObjetoEsMiPene(Transform obj);

		// Token: 0x06000580 RID: 1408
		bool ObjetoEsMiPene(Component obj);

		// Token: 0x06000581 RID: 1409
		bool ObjetoEsMiMano(Collider obj);

		// Token: 0x06000582 RID: 1410
		bool ObjetoEsMiMano(Rigidbody obj);

		// Token: 0x06000583 RID: 1411
		bool ObjetoEsMiMano(Transform obj);

		// Token: 0x06000584 RID: 1412
		bool ObjetoEsMiDedo(Collider obj);

		// Token: 0x06000585 RID: 1413
		bool ObjetoEsMiDedo(Rigidbody obj);

		// Token: 0x06000586 RID: 1414
		bool ObjetoEsMiDedo(Transform obj);

		// Token: 0x06000587 RID: 1415
		bool ObjetoEsMiDedo(Component obj);

		// Token: 0x06000588 RID: 1416
		bool ObjetoEsMiAnteBrazo(Transform obj);

		// Token: 0x06000589 RID: 1417
		void IgnorarCollosionesConManos(IReadOnlyList<Collider> others, bool ignore);

		// Token: 0x0600058A RID: 1418
		void IgnorarCollosionesConManos(IList<Collider> others, bool ignore);

		// Token: 0x0600058B RID: 1419
		void IgnorarCollosionesConManos(Collider other, bool ignore);

		// Token: 0x0600058C RID: 1420
		void IgnorarCollosionesConMano(IReadOnlyList<Collider> others, Side side, bool ignore);

		// Token: 0x0600058D RID: 1421
		void IgnorarCollosionesConMano(IList<Collider> others, Side side, bool ignore);

		// Token: 0x0600058E RID: 1422
		void IgnorarCollosionesConMano(Collider other, Side side, bool ignore);

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600058F RID: 1423
		Vector3 centerOfMassVelocity { get; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000590 RID: 1424
		Vector3 centerOfMassPosition { get; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000591 RID: 1425
		Quaternion centerOfMassRotation { get; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000592 RID: 1426
		Vector3 centerOfMassUpDirection { get; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000593 RID: 1427
		Vector3 centerOfMassForwardDirection { get; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000594 RID: 1428
		Vector3 centerOfMassRightDirection { get; }
	}
}
