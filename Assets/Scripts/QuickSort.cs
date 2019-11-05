using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Implements the QuickSort method
/// </summary>
public class QuickSort : MonoBehaviour
{
	public int[] TargetArray;

	// Use this for initialization
	void Start ()
	{
		Sort(ref TargetArray, 0, TargetArray.Length - 1);
	}

	public void Sort(ref int[] array, int minLimit, int maxLimit)
	{
		// Base case, when there is only 1 element to check
		if (minLimit >= maxLimit)
			return;

		// Partition the elements in a left and right sides and get the pivot's final position
		int pivot = Partition(ref array, minLimit, maxLimit);
		print(pivot);

		// Sort elements to each side of the pivot
		Sort(ref array, minLimit, pivot - 1);
		Sort(ref array, pivot + 1, maxLimit);
	}

	private int Partition(ref int[] array, int minLimit, int maxLimit)
	{
		// Get pivot index
		int pivot = maxLimit;
		int r = minLimit, u = minLimit;
		int temp;

		while (u < pivot)
		{
			// Compare leftmost to pivot
			if (array[u] <= array[pivot])
			{
				// Swap current unkown with the leftmost in right group
				temp = array[u];
				array[u] = array[r];
				array[r] = temp;
				r++;
			}
			u++;
		}

		// Swap leftmost in right group with the pivot
		temp = array[pivot];
		array[pivot] = array[r];
		array[r] = temp;
		pivot = r;

		return pivot;
	}

	private void PrintArray(ref int[] array)
	{
		string s = "";
		foreach (int i in array)
		{
			s += " " + i;
		}
		print(s);
	}
}
