using NLog.Targets;
using UnityEngine;

namespace NLog_Example_CheatBase
{
	[Target("NLog.CheatBase")]
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
			GameObject result = new GameObject("NLog-CheatBase");
			Instance returnValue = result.AddComponent<Instance>();
			Object.DontDestroyOnLoad(result);
			return returnValue;
		}
	}
}
