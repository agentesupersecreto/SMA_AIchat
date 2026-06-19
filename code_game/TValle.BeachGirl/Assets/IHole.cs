using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000009 RID: 9
	public interface IHole : IPenetrable, IComponentStartable
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000015 RID: 21
		IHoleInternals internals { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000016 RID: 22
		bool tieneInternals { get; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000017 RID: 23
		GameObject gameObject { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000018 RID: 24
		ICharacter owner { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000019 RID: 25
		[Obsolete("dividido en dos, visual(hole) y real(internals)", true)]
		float worldScale { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600001A RID: 26
		float worldHoleScale { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600001B RID: 27
		float worldScaleReal { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600001C RID: 28
		bool isPenetrated { get; }

		// Token: 0x0600001D RID: 29
		bool IsPenetratedBy(Collider other);

		// Token: 0x0600001E RID: 30
		IPene PenetradoPor();

		// Token: 0x0600001F RID: 31
		IPene Cercano();

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000020 RID: 32
		Transform fondoPhysics { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000021 RID: 33
		[Obsolete("era virtual, ahora se usa uno real: fondoPhysics", true)]
		Transform fondo { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000022 RID: 34
		Transform entrada { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000023 RID: 35
		Vector3 worldOutHole { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000024 RID: 36
		Vector3 worldOutHoleDirection { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000025 RID: 37
		Vector3 worldUpHoleDirection { get; }

		// Token: 0x06000026 RID: 38
		void GetWallColliders(List<Collider> result);

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000027 RID: 39
		float anchuraHoleLocalActual { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000028 RID: 40
		float profundidadHoleLocalActual { get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000029 RID: 41
		float anchuraInternalsLocalActual { get; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600002A RID: 42
		float profundidadInternalsLocalActual { get; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600002B RID: 43
		float maxProfundidadPhysicsLocal { get; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600002C RID: 44
		bool maximaProfundidadPhysicsAlcanzada { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600002D RID: 45
		float profundidadPhysicsUnClampWeigth { get; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600002E RID: 46
		float defaultAnchuraPhysicsLocal { get; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600002F RID: 47
		[Obsolete("controlado por internals", true)]
		float maxProfundidadVirtualLocal { get; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000030 RID: 48
		float maxAnchuraVirtualLocal { get; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000031 RID: 49
		[Obsolete("controlado por internals", true)]
		bool maximaProfundidadVirtualAlcanzada { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000032 RID: 50
		bool maximaAnchuraVirtualAlcanzada { get; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000033 RID: 51
		[Obsolete("controlado por internals", true)]
		float profundidadVirtualUnClampWeigth { get; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000034 RID: 52
		float anchuraVirtualUnClampWeigth { get; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000035 RID: 53
		IReadOnlyDictionary<string, HoleVirtualHardPoint> hardPoints { get; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000036 RID: 54
		IReadOnlyList<HoleVirtualHardPoint> hardPointsList { get; }

		// Token: 0x06000037 RID: 55
		bool CercaDeHardPoints();
	}
}
