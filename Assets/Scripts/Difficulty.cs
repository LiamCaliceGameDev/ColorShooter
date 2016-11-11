using UnityEngine;
using System.Collections;

public static class Difficulty {

	static float secondsToMaxDifficulty = 150;

	public static float GetDifficultyPercent() {
		return Mathf.Clamp01 (Time.time / secondsToMaxDifficulty);
	} 

}
