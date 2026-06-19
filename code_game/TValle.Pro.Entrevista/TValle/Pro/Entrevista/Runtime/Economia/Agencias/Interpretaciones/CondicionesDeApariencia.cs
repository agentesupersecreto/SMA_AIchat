using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Interpretaciones
{
	// Token: 0x020000F6 RID: 246
	[Obsolete("", true)]
	public class CondicionesDeApariencia : IInterpretacionDeAparienciaFisica
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x000301F5 File Offset: 0x0002E3F5
		IReadOnlyCollection<Interpretacion.Size> IInterpretacionDeAparienciaFisica.culo
		{
			get
			{
				return this.culo;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x000301FD File Offset: 0x0002E3FD
		IReadOnlyCollection<Interpretacion.Size> IInterpretacionDeAparienciaFisica.tetas
		{
			get
			{
				return this.tetas;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x00030205 File Offset: 0x0002E405
		IReadOnlyCollection<Interpretacion.Size> IInterpretacionDeAparienciaFisica.estatura
		{
			get
			{
				return this.estatura;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000852 RID: 2130 RVA: 0x0003020D File Offset: 0x0002E40D
		IReadOnlyCollection<Interpretacion.Capacidad> IInterpretacionDeAparienciaFisica.bodyFat
		{
			get
			{
				return this.bodyFat;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000853 RID: 2131 RVA: 0x00030215 File Offset: 0x0002E415
		IReadOnlyCollection<Interpretacion.Capacidad> IInterpretacionDeAparienciaFisica.thickness
		{
			get
			{
				return this.thickness;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x0003021D File Offset: 0x0002E41D
		IReadOnlyCollection<Interpretacion.Tono> IInterpretacionDeAparienciaFisica.tonoPiel
		{
			get
			{
				return this.tonoPiel;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000855 RID: 2133 RVA: 0x00030225 File Offset: 0x0002E425
		IReadOnlyCollection<Interpretacion.Capacidad> IInterpretacionDeAparienciaFisica.pielTrigena
		{
			get
			{
				return this.pielTrigena;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000856 RID: 2134 RVA: 0x0003022D File Offset: 0x0002E42D
		IReadOnlyCollection<Interpretacion.Tono> IInterpretacionDeAparienciaFisica.tonoCabello
		{
			get
			{
				return this.tonoCabello;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x00030235 File Offset: 0x0002E435
		IReadOnlyCollection<Interpretacion.Tono> IInterpretacionDeAparienciaFisica.tonoOjos
		{
			get
			{
				return this.tonoOjos;
			}
		}

		// Token: 0x040004A1 RID: 1185
		public SerializableEnumHashSetListSlow<Interpretacion.Size> culo = new SerializableEnumHashSetListSlow<Interpretacion.Size>();

		// Token: 0x040004A2 RID: 1186
		public SerializableEnumHashSetListSlow<Interpretacion.Size> tetas = new SerializableEnumHashSetListSlow<Interpretacion.Size>();

		// Token: 0x040004A3 RID: 1187
		public SerializableEnumHashSetListSlow<Interpretacion.Size> estatura = new SerializableEnumHashSetListSlow<Interpretacion.Size>();

		// Token: 0x040004A4 RID: 1188
		public SerializableEnumHashSetListSlow<Interpretacion.Capacidad> bodyFat = new SerializableEnumHashSetListSlow<Interpretacion.Capacidad>();

		// Token: 0x040004A5 RID: 1189
		public SerializableEnumHashSetListSlow<Interpretacion.Capacidad> thickness = new SerializableEnumHashSetListSlow<Interpretacion.Capacidad>();

		// Token: 0x040004A6 RID: 1190
		public SerializableEnumHashSetListSlow<Interpretacion.Tono> tonoPiel = new SerializableEnumHashSetListSlow<Interpretacion.Tono>();

		// Token: 0x040004A7 RID: 1191
		public SerializableEnumHashSetListSlow<Interpretacion.Capacidad> pielTrigena = new SerializableEnumHashSetListSlow<Interpretacion.Capacidad>();

		// Token: 0x040004A8 RID: 1192
		public SerializableEnumHashSetListSlow<Interpretacion.Tono> tonoCabello = new SerializableEnumHashSetListSlow<Interpretacion.Tono>();

		// Token: 0x040004A9 RID: 1193
		public SerializableEnumHashSetListSlow<Interpretacion.Tono> tonoOjos = new SerializableEnumHashSetListSlow<Interpretacion.Tono>();
	}
}
