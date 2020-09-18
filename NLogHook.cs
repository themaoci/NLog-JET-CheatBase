using NLog.Targets;
using UnityEngine;

namespace Cheat.Base
{
	[Target("Cheat.Base")]
	public sealed class Target : TargetWithLayout
	{
		public Target()
		{
			NLogHook<Instance>.Load();
		}
	}
	public class NLogHook<T> where T : MonoBehaviour
	{
		public static Instance Load()
		{
			GameObject result = new GameObject("NLog_Cheat_Base");
			Instance returnValue = result.AddComponent<Instance>();
			Object.DontDestroyOnLoad(result);
			return returnValue;
		}
	}
}
