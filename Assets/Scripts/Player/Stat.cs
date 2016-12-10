using UnityEngine;
using System.Collections;
using System;

namespace Player
{
	[Serializable]
	public class Stat : MonoBehaviour 
	{
		public string playerName;
		public int currency {get; set;}
		public int posX {get; set;}
		public int posY {get; set;}

		public enum Controller
		{
			PLAYER = 0,
			BOT = 1,
			TOTAL
		}

		public enum Type
		{
			NINJA = 0,
			SADAKO = 1,
			SHRINEMAIDEN = 2,
			WHITE_COLLAR = 3,
			TOTAL
		}

		public Controller controller;
		public Type type;
	}
}
