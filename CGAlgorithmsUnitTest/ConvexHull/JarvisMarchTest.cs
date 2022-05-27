using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CGAlgorithms.Algorithms.ConvexHull;
using CGAlgorithms;
using CGUtilities;
using System.Collections.Generic;
using System.Linq;

namespace CGAlgorithmsUnitTest
{
    /// <summary>
    /// Unit Test for Convex Hull
    /// </summary>
    [TestClass]
    public class JarvisMarchTest : ConvexHullTest
    {

        [TestMethod]
        public void PointsSubtraction()
        {
            var p1 = new Point(5, 9);
            var p2 = new Point(2, 12);

            var actual = p2 - p1;
            var excpected = new Point(-3, 3);

            Assert.AreEqual(actual, excpected);  
        }     
        
        [TestMethod]
        public void DistinictTest()
        {
            var l = new List<Point>
            {
                new Point(3, 4),
                new Point(3, 4),
            };

            //var actual = l.Select(p=>(p.X, p.Y)).Distinct().Select(p=>new Point(p.X, p.Y)).ToList();
            var actual = l.GroupBy(p => (p.X, p.Y)).Select(g=>g.First()).ToList();
            var excpected = new List<Point>
            {
                new Point(3, 4),
            };

            Assert.AreEqual(actual.Count, excpected.Count);  
        }

        [TestMethod]
        public void AngleTest()
        {
            var p1 = new Point(5, 9);
            var p2 = new Point(2, 12);

            var l1 = new Line(p1);

            var aa = l1.AngleWith(p2);  
        }


        [TestMethod]
        public void JarvisMarchTestCase1()
        {
            convexHullTester = new JarvisMarch();
            Case1();
        }
        [TestMethod]
        public void JarvisMarchTestCase2()
        {
            convexHullTester = new JarvisMarch();
            Case2();
        }
        [TestMethod]
        public void JarvisMarchTestCase3()
        {
            convexHullTester = new JarvisMarch();
            Case3();
        }
        [TestMethod]
        public void JarvisMarchTestCase4()
        {
            convexHullTester = new JarvisMarch();
            Case4();
        }
        
        [TestMethod]
        public void JarvisMarchNormalTestCase200Points()
        {
            convexHullTester = new JarvisMarch();
            Case200Points();
        }
        [TestMethod]
        public void JarvisMarchNormalTestCase400Points()
        {
            convexHullTester = new JarvisMarch();
            Case400Points();
        }
        [TestMethod]
        public void JarvisMarchNormalTestCase600Points()
        {
            convexHullTester = new JarvisMarch();
            Case600Points();
        }
        [TestMethod]
        public void JarvisMarchNormalTestCase800Points()
        {
            convexHullTester = new JarvisMarch();
            Case800Points();
        }
        [TestMethod]
        public void JarvisMarchNormalTestCase3000Points()
        {
            convexHullTester = new JarvisMarch();
            Case3000Points();
        }
        [TestMethod]
        public void JarvisMarchNormalTestCase4000Points()
        {
            convexHullTester = new JarvisMarch();
            Case4000Points();
        }
        [TestMethod]
        public void JarvisMarchNormalTestCase5000Points()
        {
            convexHullTester = new JarvisMarch();
            Case5000Points();
        }
        [TestMethod]
        public void JarvisMarchNormalTestCase10000Points()
        {
            convexHullTester = new JarvisMarch();
            Case10000Points();
        }
        [TestMethod]
        public void JarvisMarchSpecialCaseTriangle()
        {
            convexHullTester = new JarvisMarch();
            SpecialCaseTriangle();
        }
        [TestMethod]
        public void JarvisMarchSpecialCaseConvexPolygon()
        {
            convexHullTester = new JarvisMarch();
            SpecialCaseConvexPolygon();
        }
    }
}
