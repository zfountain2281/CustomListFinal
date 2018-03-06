using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListClass;

namespace CustomListTesting
{
    [TestClass]
    public class CustomListTest
    {

        [TestMethod]
        public void Add_AddFirstString_FirstItemInCustomListEqualsStringAdded()
        {
            //arrange
            string firstString = "alpha";
            CustomList<string> myList = new CustomList<string>();

            //act
            myList.Add(firstString);

            //assert
            Assert.AreEqual(myList[0], firstString);
        }

        [TestMethod]
        public void Add_AddFirstString_CustomListCountEqualsOne()
        {
            //arrange
            string firstString = "alpha";
            CustomList<string> myList = new CustomList<string>();

            //act
            myList.Add(firstString);

            //assert
            Assert.AreEqual(myList.Count, 1);
        }

        [TestMethod]
        public void Add_AddFiveItems_CustomListCountEqualsFive()
        {
            //arrange
            string testString = "alpha";
            CustomList<string> myList = new CustomList<string>();

            //act
            for (int i = 0; i < 5; i++)
            {
                myList.Add(testString);
            }

            //assert
            Assert.AreEqual(myList.Count, 5);
        }

        [TestMethod]
        public void Add_AddTwentyItems_CustomListCountEqualsTwenty()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();

            //act
            for (int i = 0; i < 5; i++)
            {
                myList.Add(i);
            }

            //assert
            Assert.AreEqual(myList.Count, 5);
        }

        [TestMethod]
        public void Add_CreateNewList_CustomListCountEqualsZero()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();

            //act

            //assert
            Assert.AreEqual(myList.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.OutOfMemoryException))]
        public void Add_AddIntMaxItems_ThrowsOutOfMemoryException()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();

            //act
            for (int i = 0; i < Int32.MaxValue; i++)
            {
                myList.Add(i);
            }
        }

        [TestMethod]
        public void Add_AddFirstObject_FirstItemEqualsObjectAdded()
        {
            //arrange
            Object obj = new Object();
            CustomList<Object> myList = new CustomList<Object>();

            //act
            myList.Add(obj);

            //assert
            Assert.AreEqual(myList[0], obj);
        }

        [TestMethod]
        public void Add_AddNullValueType_FirstItemEqualsNull()
        {
            //arrange
            int? number = null;
            CustomList<int?> myList = new CustomList<int?>();

            //act
            myList.Add(number);

            //assert
            Assert.IsNull(myList[0]);
        }

        [TestMethod]
        public void Add_AddThreeItems_LastItemInListIsLastOneAdded()
        {
            //arrange
            string itemOne = "Item1";
            string itemTwo = "Item2";
            string itemThree = "Item3";
            CustomList<string> myList = new CustomList<string>();

            //act
            myList.Add(itemOne);
            myList.Add(itemTwo);
            myList.Add(itemThree);

            //assert
            Assert.AreEqual(myList[2], itemThree);
        }

        [TestMethod]
        public void Add_AddThirtyNumbersAsStrings_IndexesEqualStringValue()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();

            //act
            for ( int i=0; i<30; i++ )
            {
                myList.Add( i.ToString() );
            }

            //assert
            Assert.AreEqual(Int32.Parse(myList[12]), 12);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Remove_AddAndRemoveOneObject_CustomListZeroIndexThrowsException()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            myList.Add(obj);

            //act
            myList.Remove(obj);
            Object newObj = myList[0];
        }

        [TestMethod]
        public void Remove_AddAndRemoveOneObject_CustomListCountIsZero()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            myList.Add(obj);

            //act
            myList.Remove(obj);

            //assert
            Assert.AreEqual(myList.Count, 0);
        }

        [TestMethod]
        public void Remove_AddFiveObjectsAndRemoveOneObject_CustomListCountIsFour()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            for (int i = 0; i < 5; i++)
            {
                myList.Add(obj);
            }

            //act
            myList.Remove(obj);

            //assert
            Assert.AreEqual(myList.Count, 4);
        }

        [TestMethod]
        public void Remove_AddFourStringsAndRemoveOneString_LastItemInCustomListIsThirdAdded()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            myList.Add("string 1");
            myList.Add("string 2");
            myList.Add("string 3");
            myList.Add("string 4");

            //act
            myList.Remove("string 4");

            //assert
            Assert.AreEqual(myList[myList.Count - 1], "string 3");
        }

        [TestMethod]
        public void Remove_AddAndRemoveOneObject_MethodReturnsTrue()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            myList.Add(obj);

            //act
            bool didRemove = myList.Remove(obj);

            //assert
            Assert.IsTrue(didRemove);
        }

        [TestMethod]
        public void Remove_AddStringAndRemoveUnfindableString_MethodReturnsFalse()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("Findable String");

            //act
            bool didRemove = myList.Remove("Unfindable String");

            //assert
            Assert.IsFalse(didRemove);
        }

        [TestMethod]
        public void Remove_AddFourIntegersAndRemoveSecondInteger_ThirdIntegerShiftsToIndexOne()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            //act
            myList.Remove(2);

            //assert
            Assert.AreEqual(myList[1], 3);
        }

        [TestMethod]
        public void Remove_AddFourIntegersAndRemoveSecondInteger_FourthIntegerShiftsToIndexTwo()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            //act
            myList.Remove(2);

            //assert
            Assert.AreEqual(myList[2], 4);
        }

        [TestMethod]
        public void Remove_AddFourIntegersAndRemoveFirstAndThirdInteger_FourthIntegerShiftsToIndexOne()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            //act
            myList.Remove(1);
            myList.Remove(3);

            //assert
            Assert.AreEqual(myList[1], 4);
        }

        [TestMethod]
        public void Remove_RemoveIntegerZeroFromEmptyList_RemoveReturnsFalse()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();

            //act
            bool result = myList.Remove(0);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_AddIntegerRunContainsForThatInteger_ResultIsTrue()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(0);

            //act
            bool result = myList.Contains(0);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_RunContainsOnEmptyList_ResultIsFalse()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();

            //act
            bool result = myList.Contains("literally anything");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_AddFindableRunsContainsOnUnfindable_ResultIsFalse()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("Findable String");

            //act
            bool result = myList.Contains("Unfindable String");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_AddTwoFindablesRunContainsOnFindable_ResultIsTrue()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("alpha");

            //act
            bool result = myList.Contains("alpha");

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_AddAndRemoveFindableRunContainsOnFindable_ResultIsFalse()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Remove("alpha");

            //act
            bool result = myList.Contains("alpha");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IndexOf_AddFourIntegersRunIndexOfOnThird_ResultIsTwo()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            //act
            int result = myList.IndexOf(3);

            //assert
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void IndexOf_AddFourIntegersRunIndexOfUnfindable_ResultIsNegativeOne()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            //act
            int result = myList.IndexOf(84);

            //assert
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void IndexOf_AddFourStringsRunIndexOfOnFourth_ResultIsThree()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("charlie");
            myList.Add("delta");

            //act
            int result = myList.IndexOf("delta");

            //assert
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void IndexOf_AddDuplicateStringsRunIndexOfOnString_ResultIsIndexOfFirstOccurance()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("charlie");
            myList.Add("delta");
            myList.Add("beta");

            //act
            int result = myList.IndexOf("beta");

            //assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void RemoveAt_AddItemRemoveAtIndexZero_CountOfCustomListIsZero()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");

            //act
            myList.RemoveAt(0);

            //assert
            Assert.AreEqual(myList.Count, 0);
        }

        [TestMethod]
        public void RemoveAt_AddFourItemsRemoveIndexTwo_ContainsReturnsFalse()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("charlie");
            myList.Add("delta");

            //act
            myList.RemoveAt(2);
            bool result = myList.Contains("charlie");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void RemoveAt_UseNegativeIndex_ThrowsIndexOutOfRangeException()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("charlie");
            myList.Add("delta");

            //act
            myList.RemoveAt(-1);

        }

        [TestMethod]
        public void GetEnumerator_AddTwoIntegersToListForeachToCalculateSum_SumIsAllCorrectSumOfAllListItems()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(1);

            //act
            int sum = 0;
            foreach (int number in myList)
            {
                sum += number;
            }

            //assert
            Assert.AreEqual(sum, 2);
        }

        [TestMethod]
        public void GetEnumerator_UseForEachToLookForString_StringIsFound()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("charlie");
            myList.Add("delta");

            //act
            bool charlieFound = false;
            foreach (string word in myList)
            {
                if (word == "charlie")
                {
                    charlieFound = true;
                }
            }

            //assert
            Assert.IsTrue(charlieFound);
        }

        [TestMethod]
        public void GetEnumerator_UseForEachToActOnObject_ObjectsInListEqualsOriginal()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new object();
            for (int i=0; i<5; i++)
            {
                myList.Add(obj);
            }

            //act
            bool objectsEqualObject = true;
            foreach (Object genericObject in myList)
            {
                if(!genericObject.Equals(obj))
                {
                    objectsEqualObject = false;
                }
            }

            //assert
            Assert.IsTrue(objectsEqualObject);
        }

        [TestMethod]
        public void ToString_AddFourStrings_ResultIsConcatenatedString()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("charlie");
            myList.Add("delta");

            //act
            string result = myList.ToString();

            //assert
            Assert.AreEqual(result, "alphabetacharliedelta");
        }

        [TestMethod]
        public void ToString_AddFourIntegers_ResultIsConcatenatedString()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            //act
            string result = myList.ToString();

            //assert
            Assert.AreEqual(result, "1234");
        }

        [TestMethod]
        public void ToString_AddFourObjects_ResultIsSystemDescriptionOfObjects()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            for (int i=0; i<4; i++)
            {
                myList.Add(new Object());
            }

            //act
            string result = myList.ToString();

            string descriptionString = "";
            for (int i = 0; i < 4; i++)
            {
                descriptionString += "System.Object";
            }

            //assert
            Assert.AreEqual(result, descriptionString);
        }

        [TestMethod]
        public void Plus_AddTwoIntegerLists_ResultIsCombinedList()
        {
            //arrange
            CustomList<int> numberListOne = new CustomList<int>();
            numberListOne.Add(1);
            numberListOne.Add(2);
            numberListOne.Add(3);
            numberListOne.Add(4);

            CustomList<int> numberListTwo = new CustomList<int>();
            numberListTwo.Add(5);
            numberListTwo.Add(6);
            numberListTwo.Add(7);
            numberListTwo.Add(8);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            expectedResult.Add(3);
            expectedResult.Add(4);
            expectedResult.Add(5);
            expectedResult.Add(6);
            expectedResult.Add(7);
            expectedResult.Add(8);

            //act
            CustomList<int> addedList = numberListOne + numberListTwo;
            bool result = true;
            for (int i = 0; i < expectedResult.Count; i++)
            {
                if (expectedResult[i] != addedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Plus_AddTwoDoubleListsFormattedDifferently_ResultIsCombinedList()
        {
            //arrange
            CustomList<double> numberListOne = new CustomList<double>();
            numberListOne.Add(.10);
            numberListOne.Add(.20);
            numberListOne.Add(.30);
            numberListOne.Add(.40);

            CustomList<double> numberListTwo = new CustomList<double>();
            numberListTwo.Add(.5);
            numberListTwo.Add(.6);
            numberListTwo.Add(.7);
            numberListTwo.Add(.8);

            CustomList<double> expectedResult = new CustomList<double>();
            expectedResult.Add(.1);
            expectedResult.Add(.20);
            expectedResult.Add(.3);
            expectedResult.Add(.40);
            expectedResult.Add(.5);
            expectedResult.Add(.60);
            expectedResult.Add(.7);
            expectedResult.Add(.80);

            //act
            CustomList<double> addedList = numberListOne + numberListTwo;
            bool result = true;
            for (int i = 0; i < expectedResult.Count; i++)
            {
                if (expectedResult[i] != addedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Plus_AddTwoStringLists_ResultIsCombinedList()
        {
            //arrange
            CustomList<string> stringListOne = new CustomList<string>();
            stringListOne.Add("alpha");
            stringListOne.Add("beta");

            CustomList<string> numberListTwo = new CustomList<string>();
            numberListTwo.Add("charlie");
            numberListTwo.Add("delta");

            CustomList<string> expectedResult = new CustomList<string>();
            expectedResult.Add("alpha");
            expectedResult.Add("beta");
            expectedResult.Add("charlie");
            expectedResult.Add("delta");

            //act
            CustomList<string> addedList = stringListOne + numberListTwo;
            bool result = true;
            for (int i = 0; i < expectedResult.Count; i++)
            {
                if (expectedResult[i] != addedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Minus_SubtracTwoIntegerLists_ResultIsSubtractedList()
        {
            //arrange
            CustomList<int> numberListOne = new CustomList<int>();
            numberListOne.Add(1);
            numberListOne.Add(2);
            numberListOne.Add(3);
            numberListOne.Add(4);

            CustomList<int> numberListTwo = new CustomList<int>();
            numberListTwo.Add(3);
            numberListTwo.Add(4);

            CustomList<int> expectedResult = new CustomList<int>();
            numberListOne.Add(1);
            numberListOne.Add(2);

            //act
            CustomList<int> subtractedList = numberListOne - numberListTwo;
            bool result = true;
            for (int i = 0; i < expectedResult.Count; i++)
            {
                if (expectedResult[i] != subtractedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Minus_SubtracTwoIntegerListsRandomOrder_ResultIsSubtractedList()
        {
            //arrange
            CustomList<int> numberListOne = new CustomList<int>();
            numberListOne.Add(12);
            numberListOne.Add(4);
            numberListOne.Add(3);
            numberListOne.Add(18);

            CustomList<int> numberListTwo = new CustomList<int>();
            numberListTwo.Add(4);
            numberListTwo.Add(12);

            CustomList<int> expectedResult = new CustomList<int>();
            numberListOne.Add(3);
            numberListOne.Add(18);

            //act
            CustomList<int> subtractedList = numberListOne - numberListTwo;
            bool result = true;
            for (int i = 0; i < expectedResult.Count; i++)
            {
                if (expectedResult[i] != subtractedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Minus_SubtracTwoIntegerListsSecondListHasUnfindables_ResultIsOriginalList()
        {
            //arrange
            CustomList<int> numberListOne = new CustomList<int>();
            numberListOne.Add(12);
            numberListOne.Add(4);
            numberListOne.Add(3);
            numberListOne.Add(18);

            CustomList<int> numberListTwo = new CustomList<int>();
            numberListTwo.Add(78);
            numberListTwo.Add(-45);

            //act
            CustomList<int> subtractedList = numberListOne - numberListTwo;
            bool result = true;
            for (int i = 0; i < numberListOne.Count; i++)
            {
                if (numberListOne[i] != subtractedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Minus_SubtracTwoStringLists_ResultIsSubtractedList()
        {
            //arrange
            CustomList<string> numberListOne = new CustomList<string>();
            numberListOne.Add("alpha");
            numberListOne.Add("beta");
            numberListOne.Add("charlie");
            numberListOne.Add("delta");

            CustomList<string> numberListTwo = new CustomList<string>();
            numberListOne.Add("alpha");
            numberListOne.Add("beta");

            CustomList<string> expectedResult = new CustomList<string>();
            numberListOne.Add("charlie");
            numberListOne.Add("delta");

            //act
            CustomList<string> subtractedList = numberListOne - numberListTwo;
            bool result = true;
            for (int i = 0; i < expectedResult.Count; i++)
            {
                if (expectedResult[i] != subtractedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Minus_SubtracTwoStringListsWithDifferentOrder_ResultIsSubtractedList()
        {
            //arrange
            CustomList<string> numberListOne = new CustomList<string>();
            numberListOne.Add("alpha");
            numberListOne.Add("beta");
            numberListOne.Add("charlie");
            numberListOne.Add("delta");

            CustomList<string> numberListTwo = new CustomList<string>();
            numberListOne.Add("beta");
            numberListOne.Add("delta");

            CustomList<string> expectedResult = new CustomList<string>();
            numberListOne.Add("alpha");
            numberListOne.Add("charlie");

            //act
            CustomList<string> subtractedList = numberListOne - numberListTwo;
            bool result = true;
            for (int i = 0; i < expectedResult.Count; i++)
            {
                if (expectedResult[i] != subtractedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Minus_SubtracTwoStringListsSecondStringHasUnfindables_ResultIsSubtractedList()
        {
            //arrange
            CustomList<string> numberListOne = new CustomList<string>();
            numberListOne.Add("alpha");
            numberListOne.Add("beta");
            numberListOne.Add("charlie");
            numberListOne.Add("delta");

            CustomList<string> numberListTwo = new CustomList<string>();
            numberListOne.Add("yankee");
            numberListOne.Add("delta");
            numberListOne.Add("zulu");
            numberListOne.Add("beta");

            CustomList<string> expectedResult = new CustomList<string>();
            numberListOne.Add("alpha");
            numberListOne.Add("charlie");

            //act
            CustomList<string> subtractedList = numberListOne - numberListTwo;
            bool result = true;
            for (int i = 0; i < expectedResult.Count; i++)
            {
                if (expectedResult[i] != subtractedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Zip_ZipTwoIntegerLists_ResultIsZippedList()
        {
            //arrange
            CustomList<int> numberListOdd = new CustomList<int>();
            numberListOdd.Add(1);
            numberListOdd.Add(3);
            numberListOdd.Add(5);

            CustomList<int> numberListEven = new CustomList<int>();
            numberListEven.Add(2);
            numberListEven.Add(4);
            numberListEven.Add(6);

            CustomList<int> expectedList = new CustomList<int>();
            expectedList.Add(1);
            expectedList.Add(2);
            expectedList.Add(3);
            expectedList.Add(4);
            expectedList.Add(5);
            expectedList.Add(6);

            //act
            CustomList<int> zippedList = numberListOdd.Zip(numberListEven);
            bool result = true;
            for (int i = 0; i < zippedList.Count; i++)
            {
                if (zippedList[i] != expectedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Zip_ZipTwoStringLists_ResultIsZippedList()
        {
            //arrange
            CustomList<string> stringListOdd = new CustomList<string>();
            stringListOdd.Add("alpha");
            stringListOdd.Add("charlie");
            stringListOdd.Add("echo");

            CustomList<string> stringListEven = new CustomList<string>();
            stringListEven.Add("bravo");
            stringListEven.Add("delta");
            stringListEven.Add("foxtrot");

            CustomList<string> expectedList = new CustomList<string>();
            expectedList.Add("alpha");
            expectedList.Add("bravo");
            expectedList.Add("charlie");
            expectedList.Add("delta");
            expectedList.Add("echo");
            expectedList.Add("foxtrot");

            //act
            CustomList<string> zippedList = stringListOdd.Zip(stringListEven);
            bool result = true;
            for (int i = 0; i < zippedList.Count; i++)
            {
                if (zippedList[i] != expectedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Zip_ZipTwoUnevenIntegerListsShorterFirst_ResultIsZippedListLimitedByShorterList()
        {
            //arrange
            CustomList<int> numberListOdd = new CustomList<int>();
            numberListOdd.Add(1);
            numberListOdd.Add(3);

            CustomList<int> numberListEven = new CustomList<int>();
            numberListEven.Add(2);
            numberListEven.Add(4);
            numberListEven.Add(6);
            numberListEven.Add(8);

            CustomList<int> expectedList = new CustomList<int>();
            expectedList.Add(1);
            expectedList.Add(2);
            expectedList.Add(3);
            expectedList.Add(4);

            //act
            CustomList<int> zippedList = numberListOdd.Zip(numberListEven);
            bool result = true;
            for (int i = 0; i < zippedList.Count; i++)
            {
                if (zippedList[i] != expectedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Zip_ZipTwoUnevenIntegerListsShorterSecond_ResultIsZippedListLimitedByShorterList()
        {
            //arrange
            CustomList<int> numberListOdd = new CustomList<int>();
            numberListOdd.Add(1);
            numberListOdd.Add(3);
            numberListOdd.Add(5);
            numberListOdd.Add(7);

            CustomList<int> numberListEven = new CustomList<int>();
            numberListEven.Add(2);
            numberListEven.Add(4);

            CustomList<int> expectedList = new CustomList<int>();
            expectedList.Add(1);
            expectedList.Add(2);
            expectedList.Add(3);
            expectedList.Add(4);

            //act
            CustomList<int> zippedList = numberListOdd.Zip(numberListEven);
            bool result = true;
            for (int i = 0; i < zippedList.Count; i++)
            {
                if (zippedList[i] != expectedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Sort_AddOutOfOrderIntegers_ResultIsSortedList()
        {
            //arrange
            CustomList<int> listToSort = new CustomList<int>();
            listToSort.Add(6);
            listToSort.Add(2);
            listToSort.Add(4);
            listToSort.Add(8);

            CustomList<int> expectedList = new CustomList<int>();
            expectedList.Add(2);
            expectedList.Add(4);
            expectedList.Add(6);
            expectedList.Add(8);

            //act
            listToSort.Sort();
            bool result = true;
            for (int i = 0; i < listToSort.Count; i++)
            {
                if (listToSort[i] != expectedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Sort_AddOutOfOrderDoubles_ResultIsSortedList()
        {
            //arrange
            CustomList<double> listToSort = new CustomList<double>();
            listToSort.Add(.60);
            listToSort.Add(.2);
            listToSort.Add(.4);
            listToSort.Add(.80);

            CustomList<double> expectedList = new CustomList<double>();
            expectedList.Add(.20);
            expectedList.Add(.40);
            expectedList.Add(.6);
            expectedList.Add(.8);

            //act
            listToSort.Sort();
            bool result = true;
            for (int i = 0; i < listToSort.Count; i++)
            {
                if (listToSort[i] != expectedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Sort_AddOutOfOrderStrings_ResultIsSortedList()
        {
            //arrange
            CustomList<string> listToSort = new CustomList<string>();
            listToSort.Add("r");
            listToSort.Add("i");
            listToSort.Add("c");
            listToSort.Add("k");

            CustomList<string> expectedList = new CustomList<string>();
            expectedList.Add("c");
            expectedList.Add("i");
            expectedList.Add("k");
            expectedList.Add("r");

            //act
            listToSort.Sort();
            bool result = true;
            for (int i = 0; i < listToSort.Count; i++)
            {
                if (listToSort[i] != expectedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Sort_AddOutOfOrderComplexStrings_ResultIsSortedList()
        {
            //arrange
            CustomList<string> listToSort = new CustomList<string>();
            listToSort.Add("!hello");
            listToSort.Add("how");
            listToSort.Add("are");
            listToSort.Add("you?");

            CustomList<string> expectedList = new CustomList<string>();
            listToSort.Add("!hello");
            expectedList.Add("are");
            listToSort.Add("how");
            listToSort.Add("you?");

            //act
            listToSort.Sort();
            bool result = true;
            for (int i = 0; i < listToSort.Count; i++)
            {
                if (listToSort[i] != expectedList[i])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Sort_LargeListOfRandomIntegers_ResultIsSortedList()
        {
            //arrange
            CustomList<int> listToSort = new CustomList<int>();
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                listToSort.Add(random.Next(0, 1001));
            }

            //act
            listToSort.Sort();
            bool result = true;
            for (int i = 0; i < listToSort.Count; i++)
            {
                if (listToSort[i] > listToSort[i + 1])
                {
                    result = false;
                }
            }

            //assert
            Assert.IsTrue(result);
        }

    }
}
