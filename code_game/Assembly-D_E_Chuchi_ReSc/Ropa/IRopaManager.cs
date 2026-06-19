using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000D5 RID: 213
	public interface IRopaManager : IComponentStartable
	{
		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06000523 RID: 1315
		// (remove) Token: 0x06000524 RID: 1316
		event OnRopaManagerChangedHandler changed;

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000525 RID: 1317
		// (remove) Token: 0x06000526 RID: 1318
		event Action<IRopaManager> conjuntoLoaded;

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000527 RID: 1319
		bool isLoadingConjunto { get; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000528 RID: 1320
		RopaCubre cubriendoFlags { get; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000529 RID: 1321
		// (set) Token: 0x0600052A RID: 1322
		IConjuntoDeRopa conjuntoToLoad { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600052B RID: 1323
		IConjuntoDeRopa loadedConjunto { get; }

		// Token: 0x0600052C RID: 1324
		IEnumerator LoadConjunto(Action onEnd = null, bool showLoadingScreen = true);

		// Token: 0x0600052D RID: 1325
		IEnumerator LoadConjuntoAsset(IConjuntoDeRopa conjuntoAsset, bool removerExistentes, Action onEnd = null, bool showLoadingScreen = true);

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600052E RID: 1326
		IReadOnlyList<PiezaDeRopaBase> piezasPuestas { get; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600052F RID: 1327
		IReadOnlyDictionary<string, PiezaDeRopaBase> piezasPuestasPorId { get; }

		// Token: 0x06000530 RID: 1328
		RopaCubre CurrentPiezaCubreFlags(string PiezaID, bool ignorarOcultas);

		// Token: 0x06000531 RID: 1329
		RopaCubre PiezaCubreFlags(string piezaID, bool ignorarSiEstaOculta);

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000532 RID: 1330
		[Obsolete("Se unificaron los mapas", true)]
		RopaTipoDeSingleton ropaTipoDeSingleton { get; }

		// Token: 0x06000533 RID: 1331
		[Obsolete("", true)]
		IRopaParaAvatar ObtenerMapa();

		// Token: 0x06000534 RID: 1332
		IEnumerator UpdateMaterialAsync(string pendaID, string newMaterialID, int materialSlot, Color color, Action<bool> output);

		// Token: 0x06000535 RID: 1333
		IEnumerator AddPiezaAsync<T_PiezaDeRopaAbstract>(Pieza piezaPrefab, Action<T_PiezaDeRopaAbstract> output, bool showLoadingScreen) where T_PiezaDeRopaAbstract : PiezaDeRopaBase;

		// Token: 0x06000536 RID: 1334
		IEnumerator AddPiezaAsync<T_PiezaDeRopaAbstract>(string ropaId, IReadOnlyList<SlotDeMaterialDeRopa> materiales, Action<T_PiezaDeRopaAbstract> output, bool showLoadingScreen) where T_PiezaDeRopaAbstract : PiezaDeRopaBase;

		// Token: 0x06000537 RID: 1335
		bool RemovePieza(string ropaId, bool destroy, Object by);

		// Token: 0x06000538 RID: 1336
		bool OcultarPieza(string ropaId, bool ocultar, Object by);

		// Token: 0x06000539 RID: 1337
		bool OcultarPiezasCubriendo(RopaCubre flags, bool ocultar, Object by = null);

		// Token: 0x0600053A RID: 1338
		int CantidadPiezasCubriendo(RopaCubre flags, bool ignorarOcultas, IList<string> IDsResultado = null);

		// Token: 0x0600053B RID: 1339
		void ObtenerPiezasIDs(ICollection<string> resultado, bool ignorarOcultas);

		// Token: 0x0600053C RID: 1340
		bool Usando(string PiezaID, bool ignorarOcultas);

		// Token: 0x0600053D RID: 1341
		T GenerarConjuntoDePiezasConEstadoActual<T>() where T : IConjuntoDeRopaMutable, new();

		// Token: 0x0600053E RID: 1342
		void RemoverTodo();

		// Token: 0x0600053F RID: 1343
		void ToggleTodo(bool ocultar);
	}
}
