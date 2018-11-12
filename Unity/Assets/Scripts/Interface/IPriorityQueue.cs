using System;

namespace ProjectZGL
{
	/// <summary>
	/// Represents a prioritized queue.
	/// </summary>
	public interface IPriorityQueue<T>
	{
		/// <summary>
		/// Number of items in the queue.
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Method adds item to the queue.
		/// </summary>
		void Enqueue(T item, int priority);
		/// <summary>
		/// Method returns item with the LOWEST priority value.
		/// </summary>
		T Dequeue();
	}

	/// <summary>
	/// Represents a node in a priority queue.
	/// </summary>
	class PriorityQueueNode<T> : IComparable
	{
		public T Item { get; private set; }
		public float Priority { get; private set; }

		public PriorityQueueNode(T item, float priority)
		{
			Item = item;
			Priority = priority;
		}

		public int CompareTo(object obj)
		{
			return Priority.CompareTo((obj as PriorityQueueNode<T>).Priority);
		}
	}



}
