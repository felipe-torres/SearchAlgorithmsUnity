using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Implements the mergesort algorithm
/// </summary>
public class MergeSort : MonoBehaviour
{
	public int[] TargetArray;

	// Use this for initialization
	void Start ()
	{
		Sort(ref TargetArray, 0, TargetArray.Length-1);
	}

	public void Sort(ref int[] array, int minLimit, int maxLimit)
	{
		// Base case, when there is only 1 element to check
		if (minLimit >= maxLimit)
			return;
		// Find midpoint of subarray
		int midIndex = (int)((maxLimit + minLimit) * 0.5f);
		Sort(ref array, minLimit, midIndex);
		Sort(ref array, midIndex + 1, maxLimit);
		Merge(ref array, minLimit, midIndex, maxLimit);
	}

	private void Merge(ref int[] array, int minLimit, int midIndex, int maxLimit)
	{
		int[] lowHalf = new int[midIndex - minLimit + 1];
		int[] highHalf = new int[maxLimit - midIndex];
		// Make a copy of each half to merge
		Array.Copy(array, minLimit, lowHalf, 0, midIndex - minLimit + 1);
		Array.Copy(array, midIndex + 1, highHalf, 0, maxLimit - midIndex);

		int i = 0, j = 0, k = minLimit;
		while (i<lowHalf.Length && j<highHalf.Length)
		{
			// Compare between halfs
			if (lowHalf[i] <= highHalf[j])
			{
				array[k] = lowHalf[i];
				i++;
			}
			else
			{
				array[k] = highHalf[j];
				j++;
			}
			k++;
		}

		while(i<lowHalf.Length)
		{
			array[k++] = lowHalf[i++];
		}
		while(j<highHalf.Length)
		{
			array[k++] = highHalf[j++];
		}
	}
}
