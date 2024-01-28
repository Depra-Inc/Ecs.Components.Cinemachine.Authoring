// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

namespace Depra.Ecs.Components.Cinemachine.Authoring
{
	internal static class Module
	{
		public const int DEFAULT_ORDER = 52;

		public const string MENU_PATH = nameof(Ecs) + SLASH +
		                                nameof(Components) + SLASH +
		                                nameof(Cinemachine) + SLASH;

		private const string SLASH = "/";
	}
}