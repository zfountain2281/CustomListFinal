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

            string firstString = "alpha";
            CustomList<string> myList = new CustomList<string>();

            myList.Add(firstString);

            Assert.AreEqual(myList[0], firstString);
        }

        [TestMethod]
        public void Add_AddFirstString_CustomListCountEqualsOne()
        {

            string firstString = "alpha";
            CustomList<string> myList = new CustomList<string>();


            myList.Add(firstString);


            Assert.AreEqual(myList.Count, 1);
        }

        [TestMethod]
        public void Add_AddFiveItems_CustomListCountEqualsFive()
        {

            string testString = "alpha";
            CustomList<string> myList = new CustomList<string>();


            for (int i = 0; i < 5; i++)
            {
                myList.Add(testString);
            }


            Assert.AreEqual(myList.Count, 5);
        }

        [TestMethod]
        public void Add_AddTwentyItems_CustomListCountEqualsTwenty()
        {

            CustomList<int> myList = new CustomList<int>();


            for (int i = 0; i < 5; i++)
            {
                myList.Add(i);
            }


            Assert.AreEqual(myList.Count, 5);
        }

        [TestMethod]
        public void Add_CreateNewList_CustomListCountEqualsZero()
        {

            CustomList<int> myList = new CustomList<int>();



            Assert.AreEqual(myList.Count, 0);
        }



        [TestMethod]
        public void Add_AddFirstObject_FirstItemEqualsObjectAdded()
        {

            Object obj = new Object();
            CustomList<Object> myList = new CustomList<Object>();


            myList.Add(obj);


            Assert.AreEqual(myList[0], obj);
        }


        [TestMethod]
        public void Remove_AddAndRemoveOneObject_CustomListCountIsZero()
        {
            
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            myList.Add(obj);

            
            myList.Remove(obj);

            
            Assert.AreEqual(myList.Count, 0);
        }


        [TestMethod]
        public void Remove_AddFourStringsAndRemoveOneString_LastItemInCustomListIsThirdAdded()
        {
            
            CustomList<Object> myList = new CustomList<Object>();
            myList.Add("string 1");
            myList.Add("string 2");
            myList.Add("string 3");
            myList.Add("string 4");

            
            myList.Remove("string 4");

            
            Assert.AreEqual(myList[myList.Count - 1], "string 3");
        }

        [TestMethod]
        public void Remove_AddAndRemoveOneObject_MethodReturnsTrue()
        {
            
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            myList.Add(obj);

            
            bool didRemove = myList.Remove(obj);

           
            Assert.IsTrue(didRemove);
        }


        [TestMethod]
        public void Remove_AddFourIntegersAndRemoveSecondInteger_FourthIntegerShiftsToIndexTwo()
        {
           
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

         
            myList.Remove(2);

            Assert.AreEqual(myList[2], 4);
        }



        [TestMethod]
        public void Contains_AddIntegerRunContainsForThatInteger_ResultIsTrue()
        {
            
            CustomList<int> myList = new CustomList<int>();
            myList.Add(0);

           
            bool result = myList.Contains(0);

            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_RunContainsOnEmptyList_ResultIsFalse()
        {
           
            CustomList<string> myList = new CustomList<string>();

            
            bool result = myList.Contains("literally anything");

           
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_AddFindableRunsContainsOnUnfindable_ResultIsFalse()
        {
            
            CustomList<string> myList = new CustomList<string>();
            myList.Add("Findable String");

           
            bool result = myList.Contains("Unfindable String");

          
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_AddTwoFindablesRunContainsOnFindable_ResultIsTrue()
        {
            
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("alpha");

            
            bool result = myList.Contains("alpha");

            
            Assert.IsTrue(result);
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
            for (int i = 0; i < 4; i++)
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



    }
}
