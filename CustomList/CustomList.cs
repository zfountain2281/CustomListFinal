using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListClass
{
    public class CustomList<T> : IEnumerable<T>
    {
        int count;
        int capacity;
        T[] listItems;

        public int Count
        {
            get { return count; }
        }

        public int Capacity
        {
            get { return capacity; }
        }

    
        public T this [int i]
        {
            get
            {
                if ( i > count-1 )
                {
                    throw new Exception("Index out of range of CustomList");
                }
                else
                {
                    return listItems[i];
                }
            }
            set
            {
                listItems[i] = value;
            }
        }

 
        public CustomList()
        {
            count = 0;
            capacity = 5;
            listItems = new T[capacity];
        }

        T[] GetLargerArray()
        {
            capacity *= 2;
            T[] largerArray = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                largerArray[i] = listItems[i];
            }
            return largerArray;
        }

        public void Add(T item)
        {
            if ( count * 2 >= capacity )
            {
                T[] largerArray = GetLargerArray();
                listItems = largerArray;
            }
            listItems[count] = item;
            count++;
        }

        public bool Contains(T item)
        {
            for ( int i=0; i<count; i++ )
            {
                if ( listItems[i].Equals(item) )
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i=0; i<count; i++)
            {
                if ( listItems[i].Equals(item) )
                {
                    return i;
                }
            }
            return -1;
        }

        public void RemoveAt(int itemIndex)
        {
            for (int i = itemIndex+1; i < count; i++)
            {
                listItems[i - 1] = listItems[i];
            }
            count--;
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }
            int itemIndex = IndexOf(item);
            RemoveAt(itemIndex);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for ( int i=0; i<count; i++ )
            {
                yield return listItems[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                result.Append(listItems[i]);
            }
            return result.ToString();
        }

        CustomList<T> AddToList(CustomList<T> listToAdd)
        {
            CustomList<T> addedList = this;
            for (int i = 0; i < listToAdd.Count; i++)
            {
                addedList.Add(listToAdd[i]);
            }
            return addedList;
        }

        public static CustomList<T> operator +(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> addedList = new CustomList<T>();
            addedList.AddToList(listOne);
            addedList.AddToList(listTwo);
            return addedList;
        }

        CustomList<T> SubtractFromList(CustomList<T> listToSubtract)
        {
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = 0; j < listToSubtract.Count; j++)
                {
                    if (this[i].Equals(listToSubtract[j]))
                    {
                        this.Remove(listToSubtract[j]);
                    }
                }
            }
            return this;
        }

        public static CustomList<T> operator -(CustomList<T> listOne, CustomList<T> listTwo)
        {
            listOne.SubtractFromList(listTwo);
            return listOne;
        }

        int GetMaxCount(CustomList<T> listOne, CustomList<T> listTwo)
        {
            if (listOne.Count <= listTwo.Count)
            {
                return listOne.Count;
            }
            else
            {
                return listTwo.Count;
            }
        }

        public CustomList<T> Zip(CustomList<T> listTwo)
        {
            CustomList<T> zippedList = new CustomList<T>();
            int maxCount = GetMaxCount(this, listTwo);
            for (int i=0; i<maxCount; i++)
            {
                zippedList.Add(this[i]);
                zippedList.Add(listTwo[i]);
            }
            return zippedList;
        }

        public CustomList<T> Sort()
        {
            Type type = listItems.GetType().GetElementType();
            if (!type.GetInterfaces().Contains(typeof(IComparable)))
            {
                return this;
            }
            if (type.ToString() == "System.Int32" )
            {
                int[] numbers = new int[count];
                for ( int i=0; i<count; i++ )
                {
                    numbers[i] = Convert.ToInt32(listItems[i]);
                }
                SortQuick(numbers, 0, count-1);
                return numbers as CustomList<T>;
            }

            return this;
        }



        static public int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        static public void SortQuick(int[] arr, int left, int right)
        {

            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                    SortQuick(arr, left, pivot - 1);

                if (pivot + 1 < right)
                    SortQuick(arr, pivot + 1, right);
            }
        }

    }
}
