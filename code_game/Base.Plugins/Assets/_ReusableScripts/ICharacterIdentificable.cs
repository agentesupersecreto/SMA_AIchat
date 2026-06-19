using System;

namespace Assets._ReusableScripts
{
	// Token: 0x02000175 RID: 373
	public interface ICharacterIdentificable : ICharacterUnico, ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable
	{
		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000B18 RID: 2840
		bool isBinded { get; }

		// Token: 0x06000B19 RID: 2841
		void Bind(string nuevoNombreCompleto, string nuevoNombre, string nuevoApellido, Guid nuevoID);

		// Token: 0x06000B1A RID: 2842
		void UpdateName(string nuevoNombreCompleto, string nuevoNombre, string nuevoApellido);
	}
}
