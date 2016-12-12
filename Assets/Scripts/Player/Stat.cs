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
		public int sequence; 

		public enum Controller
		{
			PLAYER = 0,
			BOT = 1,
			TOTAL
		}

		public enum Type
		{
			KAYAKO = 0,
			SADAKO = 1,
			DEMON_FOX = 2,
			JAMI = 3,
			TOTAL
		}

		public Controller controller;
		public Type type;

		void Start()
		{
			
		}
	}
}
