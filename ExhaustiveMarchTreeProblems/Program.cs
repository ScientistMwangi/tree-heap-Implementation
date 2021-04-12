using System;
using System.Collections.Generic;

namespace ExhaustiveMarchTreeProblems
{
    class Program
    {
        private static Node LargestBSTInBTTree()
        {
            Node root = new Node (10);
            Node n1 = new Node(6);
            Node n2 = new Node(12);
            Node n3 = new Node(7);
            Node n4 = new Node(4);
            Node n5 = new Node(9);
            Node n6 = new Node(14);
            Node n7 = new Node(13);
            Node n8 = new Node(16);

            root.left = n1;
            root.right = n2;

            n1.left = n3;
            n1.right = n4;

            n2.left = n5;
            n2.right = n6;

            n6.left = n7;
            n6.right = n8;

            return root;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Tree Traversal: ");
            Tree t = new Tree();
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);

            root.left.left = new Node(4);
            root.left.right = new Node(5);

            root.right.left = new Node(6);
            root.right.right = new Node(7);

            /*
             * Create a sample tree
             *              1
             *      2               3
             * 4        5       6       7
             * 
             */

            Console.WriteLine("In-order T Tree records: "+t.InorderTraversal(root, ""));
            Console.WriteLine("Pre-order T Tree records: " + t.PreOrderTraversal(root, ""));
            Console.WriteLine("Post-order T Tree records: " + t.PostOrderTraversal(root, ""));
            Console.WriteLine("Level-order T Tree records: " + t.LevelOrderTraversal(root, ""));
            Console.WriteLine("Tree Size: " + t.TreeSize(root));
            Console.WriteLine("Height of a Tree : " + t.Height(root));
            //Console.WriteLine("IsBinary Tree: "+ t.IsBTS(root, int.MinValue, int.MaxValue));

            // Insert bst
            int[] arr = {4,5,2,6,7,3,1,45,56,8,67,77,44,33 };
            int[] arr2 = { 8,3,10,1,6 };
            Node r = new Node(0);
            Tree t2 = new Tree();
            foreach (int v in arr2)
                t2.Insert(r, v);
            /*
             * Create a sample tree
             *              8
             *       3              10
             *    1     6
             *     
             * 
             */
            Console.WriteLine("Level-order T2 Tree records: " + t.PreOrderTraversal(r, ""));
            Console.WriteLine("IsBinary Tree: " + t.IsBTS(r, int.MinValue, int.MaxValue));
            PrintTreeLeftView(r);

            // Right View Print
            /**
             *                 1
             *           2           3
             *        5     6     7
             * 
             * 
             * **/
            Node t3 = new Node(1);
            t3.left = new Node(2);
            t3.right = new Node(3);
            t3.left.left = new Node(5);
            t3.left.right = new Node(6);
            t3.right.left = new Node(7);
            // Did not work
            //Console.WriteLine("Right view of a tree: "+ RightSideView(t3));  
            Console.WriteLine("Print Right Side view of a tree Iterative: " + string.Join(",", RightSideViewWorked(t3)));
            Console.WriteLine("Print Right Side view of a tree Recursion: " + string.Join(",", PrintRightViewRecursion(t3, new List<int>(), 1)));
            Console.WriteLine("Print Left Side view of a tree Recursion: " + string.Join(",", LeftSideViewRecursion(t3, new List<int>(), 1)));

            // Print nodes with no siblings
            Console.WriteLine();
            Console.WriteLine("Nodes with no siblings : "+ string.Join(", ",NodesWithNoSiblings(CreateTree())));
            // Print paths to leafs
            Console.WriteLine();
            Console.WriteLine("All Paths to leaf");
            PrintAllPathsToLeafsHelper(t3);
            TestReturn1();

            // Minimum Tree height
            Console.WriteLine();
            Console.WriteLine("Minimum height "+ GetMinimunHeight(t3));
            // Sum of left leaf nodes
            int[] s = new int[1];
            SumLeft (t3, s);
            Console.WriteLine("Sum of the Left nodes: "+ s[0]);
            Console.WriteLine("Deepest odd level of a leaf " + DeepestOddLeafSize(createSampleTree1(), 1));

            // Check if nodes are cousin
            Console.WriteLine(" Are Node Cousins: "+ IsCousins(t3, 5, 7));

            Console.WriteLine();
            Console.WriteLine("Level=====>>");
            NodePerLevel(t3);
            // Are trees Identical
            Node t4 = new Node(1);
            Node t4l = new Node(2);
            t4.left = t4l;

            Node t5 = new Node(1);
            Node t5r = new Node(2);
            t5.right = t5r;

            Console.WriteLine();
            Console.WriteLine("Are the Two Trees Identical?: "+ AreIdentical(t4, t5));

            // BST one child per node
            Console.WriteLine();
            int[] preorderTree1 = { 9, 8, 5, 7, 6 };
            int[] preorderTree2 = { 8, 5, 4, 7, 6 };
            Console.WriteLine($"Bst have single child per node pre order Traversal array without creating a tree: array: {string.Join(", ",preorderTree1)} is it?: {NodeHas1ChildBST(preorderTree1)}");
            Console.WriteLine($"Bst have single child per node pre order Traversal array without creating a tree: array: {string.Join(", ", preorderTree2)} is it?: {NodeHas1ChildBST(preorderTree2)}");

            //Mirror tree
            Console.WriteLine($"B4 Mirror: {t.InorderTraversal(t3, "")} ");
            InvertTree(t4);
            Console.WriteLine($"After Mirror: {t.InorderTraversal(t3, "")} ");

            // Print view Top Recursion
            var dic = new Dictionary<int, MapContainer>();
            PrintTopView(TopViewTree(), dic, 0, 0);

            // Print View Top using LevelOrder Traversal
            var dicRe = new Dictionary<int, int>();
            PrintTopViewLevelOrderTraversal(TopViewTree(), dicRe);

            // Print Bottom view using recursion
            var resBottomRecu = new Dictionary<int, MapContainer>();
            PrintBottomViewRecursion(TopViewTree(), resBottomRecu, 0, 0);

            // Print bottom view using levelorder traversal
            var resBottomLevelOrderTra = new Dictionary<int, int>();
            PrintBottomViewLevelOrderTraversal(TopViewTree(), resBottomLevelOrderTra);


            TestRecursion(RemoveSumNodeLessKTree());
            // Print All the paths values from the root less than k
            int[] sum = new int[1];
            //int[] rs = new int[1];
            DeleteNodePathSumLessThank(RemoveSumNodeLessKTree(), 23, sum);

            // Delete half nodes
            var rootRes = DeleteHalfNode(RemoveSumNodeLessKTree());

            // Diagonal Sum
            var totalSum = DiagonalSumOfTree(SumDiagonalTree());

            // Convert Tree to doubleLinkedList
            //var doubleLinkedList = ConvertTreeToDDLL(SumDiagonalTree());

            // FInd Matching nodes b
            Node stRoot = new Node(3);
            Node st1 = new Node(4);
            Node st2 = new Node(5);
            Node st3 = new Node(1);
            Node st4 = new Node(2);
            Node st5 = new Node(0);
            stRoot.right = st2;stRoot.left = st1;
            st1.left = st3; st2.right = st4;
            st3.left = st5;

            Node st2Root = new Node(4);
            Node st2L = new Node(1);
            Node st2R = new Node(2);
            st2Root.left = st2L;st2Root.right = st2R;

            var isSubTree = IsSubtree(stRoot, st2Root);
            List<int> arr10 = new List<int>{ 6, 4, 10, 9, 12, 13, 14, 16 };
            
            var res = LongestInIncrease(arr10);

            //Largest BST in BT
            List<int> lAnswer = new List<int>();
            
            InOrderTraversal(LargestBSTInBTTree(), lAnswer);
            var res2 = LongestInIncrease(lAnswer);

            // AVL Tree insert, delete


            // Tries
            TrieOperatons trie = new TrieOperatons();
            trie.Insert("car");
            trie.Insert("cat");
            trie.Insert("xyz");
            trie.Insert("xyzb");
            trie.Insert("abb");
            trie.Insert("abc");
            trie.Insert("eat");

            var s1 = trie.Search("cow");// false
            var s2 = trie.Search("ca");// false start with
            var s3 = trie.Search("catr"); // false 
            var s4 = trie.Search("car");// true

            var dt = trie.Delete("eat",trie.root, 0, 3);
            Console.WriteLine("abc deleted from the trie");

            // Deserialize Tree
            // PreOrder array
            int [] preOrderArray = { 5, 2, 1, 3, 4, 7, 6, 8 };
            int[] postOrder = { 1, 4, 3, 2, 6, 8, 7, 5 };
            int[] index = { 0 };
            Console.WriteLine("In-order T Tree records: after serialization of preOrderArray " + t.InorderTraversal(ConstructTreeFromPreOrderArray(preOrderArray, index, int.MinValue, int.MaxValue),""));

            // Post-Order Traversal
            int[] elementIndex = { postOrder.Length -1 };
            Console.WriteLine("Level-order T Tree records: After serialization of postOrderArray" + t.LevelOrderTraversal(ConstructTreeFromPostOrderArray(postOrder, elementIndex, int.MinValue, int.MaxValue), ""));


            Tree avlT = new Tree();
            //AVLTreeNode avl root = new AVLTreeNode();
            var avlRoot = avlT.InsertAVL(null ,20);
            var bT1 = avlT.InsertAVL(avlRoot, 10);
            var bT2 = avlT.InsertAVL(avlRoot, 11);

            // Heaps
            // MinHeap Implementation
            MinHeap minHeap = new MinHeap();
            minHeap.Insert(20);
            minHeap.Insert(10);
            minHeap.Insert(0);
            minHeap.Insert(15);
            minHeap.Insert(17);
            Console.WriteLine();
            Console.WriteLine("Min Heap:******************");
            Console.WriteLine();
            Console.WriteLine($"Print min heap: {minHeap.ToString()}");
            minHeap.Insert(-12);
            Console.WriteLine($"Print min heap: {minHeap.ToString()}");
            int deleteHeap = 0;
            Console.WriteLine($"Delete from the heap: {deleteHeap}");
            minHeap.Delete(deleteHeap);
            Console.WriteLine($"Print min heap after delete: {deleteHeap}=> No change as it is not the root   : {minHeap.ToString()}");
            Console.WriteLine($"Delete from the heap pass root value : -12");
            minHeap.Delete(-12);
            Console.WriteLine($"Print min heap after deleting the root: -12   => root removed and replaced with next small value   : {minHeap.ToString()}");

        }

        public static Node ConstructTreeFromPostOrderArray(int [] postOrder, int[] elementIndex, int min, int max)
        {
            Node root = null;
            if (elementIndex[0] < 0) return root;
           
            if (min < postOrder[elementIndex[0]] && postOrder[elementIndex[0]] < max )
            {
                root = new Node(postOrder[elementIndex[0]]);
                elementIndex[0] -= 1;
                root.right = ConstructTreeFromPostOrderArray(postOrder, elementIndex, root.key, max);
                root.left = ConstructTreeFromPostOrderArray(postOrder, elementIndex, min, root.key);
            }
            return root;
        }

        public static Node ConstructTreeFromPreOrderArray(int [] preOrder, int [] index, int min, int max)
        {
            Node root = null;
            if (preOrder.Length <= index[0]) return root;
            
            if(preOrder[index[0]] > min &&  max > preOrder[index[0]]){
                root = new Node(preOrder[index[0]]);
                index[0] += 1;
                root.left = ConstructTreeFromPreOrderArray(preOrder, index, min, root.key);
                root.right = ConstructTreeFromPreOrderArray(preOrder, index, root.key, max);
            }
            return root;
        }
        public static void InOrderTraversal(Node root, List<int> res)
        {
            if (root != null)
            {
                if (root.left != null) InOrderTraversal(root.left, res);
                res.Add(root.key);
                if (root.right != null) InOrderTraversal(root.right, res);
            }

        }
        public static bool IsSubtree(Node s, Node t)
        {
            if (s == null && t == null) return true;
            Console.WriteLine(NodeMatch(s, t));
            var startNode = NodeMatch(s, t);
            if (startNode == null) return false;
            if (s == null || t == null)
            {
                return s == null && t == null;
            }
            return IsSame(startNode.left, t.left) && IsSame(startNode.right, t.right);
        }

        public static int LongestInIncrease(List<int>nums)
        {
            nums.ToArray();
            int max = 1;
            int count = 1;

            for(int i = 1; i < nums.ToArray().Length; i++)
            {
                if(nums[i-1] < nums[i])
                {
                    count ++;
                }
                else
                {
                    count = 1;
                }
                max = Math.Max(count, max);
            }
            return max;
        }
        public static bool IsSame(Node n1, Node n2)
        {
            if (n1 == null || n2 == null)
            {
                return n1 == null && n2 == null;
            }
            if(n1.key != n2.key){

                return false;
            }

            return IsSame(n1.left, n2.left) && IsSame(n1.right, n2.right);
        }

        public static Node NodeMatch(Node s, Node t)
        {
            if (s.key == t.key) return s;
            Node res = null;
            if (s.left != null)
            {
                res = NodeMatch(s.left, t);
            }
            if (s.right != null && res == null)
            {
                res = NodeMatch(s.right, t);
            }

            /*if(res == null){
                 res = NodeMatch(s.right, t);
            }*/
            return res;
        }

        public static DDLinekdList ConvertTreeToDDLL(Node root)
        {
            Stack<int> q = new Stack<int>();
            Stack<Node> s = new Stack<Node>();
            if (root == null) return null;
            s.Push(root);
            while(s.Count != 0)
            {
                Node popedNode = null;
                var node = s.Peek();
                if(node.left != null)
                {
                    s.Push(node.left);
                }
                else
                {
                    popedNode = s.Pop();
                    if (popedNode.right != null)
                    {
                        s.Push(popedNode.right);
                    }
                }

                

                if (popedNode != null) q.Push(popedNode.key);
            }

            DDLinekdList head = null;
            

            while (q.Count != 0)
            {
                DDLinekdList newNode = new DDLinekdList(q.Pop());

                if(head == null)
                {
                    head = newNode;
                }
                else
                {
                    
                    newNode.next = head;
                    head.prev = newNode;
                    newNode = head;
                }
            }
            return head;
        }
        public static Node SumDiagonalTree()
        {
            Node root = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            Node n7 = new Node(7);
            Node n8 = new Node(8);
            Node n9 = new Node(9);
            Node n10 = new Node(10);
            Node n11 = new Node(11);
            Node n12 = new Node(12);

            root.left = n2; root.right = n3;
            n2.left = n9; n2.right = n6;n9.right = n10; n6.left = n11;
            n3.left = n4; n3.right = n5;
            n4.left = n12; n4.right = n7;


            return root;
        }
        public static Dictionary<int, int> DiagonalSumOfTree(Node root)
        {
            Dictionary<int, int> sum = new Dictionary<int, int>();
            if (root == null) return sum;
            Queue<NodeMapContainer> q = new Queue<NodeMapContainer>();
            q.Enqueue(new NodeMapContainer(0, root));
            //sum[0] = root.key;

            while (q.Count != 0)
            {
                var node = q.Dequeue();
                if (sum.ContainsKey(node.currentLevel))
                {
                    sum[node.currentLevel] += node.value.key;
                }
                else
                {
                    sum[node.currentLevel] = node.value.key;
                }
                
                // Left from root maintain the diagonal space line n
                if(node.value.left != null)
                {
                    q.Enqueue(new NodeMapContainer(node.currentLevel  + 1, node.value.left));
                }
                // Right from root goes to diagonal space line n+1
                if (node.value.right != null)
                {
                    q.Enqueue(new NodeMapContainer(node.currentLevel, node.value.right));
                }
            }

            return sum;
        }

        public static Node DeleteHalfNode(Node root)
        {
            if (root == null) return null;
            root.left = DeleteHalfNode(root.left);
            root.right = DeleteHalfNode(root.right);
            if (root.left == null && root.right != null)
            {
                root = root.right;
            }
            if(root.right == null && root.left != null)
            {
                root = root.left;
            }

            return root;

        }


        public static Node DeleteNodePathSumLessThank(Node root, int K, int []sum)
        {
            if (root == null) return null;

            sum[0] += root.key;
            int [] ls= sum;
            int [] rs = sum;
            root.left = DeleteNodePathSumLessThank(root.left, K, ls);
            root.right = DeleteNodePathSumLessThank(root.right, K, rs);

            if(K > Math.Max(ls[0], rs[0]))
            {
                root = null;
                //sum[0] = 0;
            }
            return root;
        }


        public static void TestRecursion(Node root)
        {
            if (root == null) return;
            TestRecursion(root.left);
            TestRecursion(root.right);
            Console.WriteLine(root.key);
        }
        public static void PrintBottomViewRecursion(Node root, Dictionary<int, MapContainer> res, int horizontalDistance, int currentLevel )
        {
            if (root == null) return;
            if (res.ContainsKey(horizontalDistance))
            {
                // here if the level is already there take the deepest level
                var seenNode = res[horizontalDistance];
                if(currentLevel >= seenNode.currentLevel)
                {
                    res[horizontalDistance] = new MapContainer(currentLevel, root.key);
                }
            }
            else
            {
                res[horizontalDistance] = new MapContainer(currentLevel, root.key);
            }
            PrintBottomViewRecursion(root.left, res, horizontalDistance -1, currentLevel+1);
            PrintBottomViewRecursion(root.right, res, horizontalDistance +1, currentLevel+1);
        }


        public static void PrintBottomViewLevelOrderTraversal(Node root, Dictionary<int, int> res)
        {
            if (root == null) return;
            Queue<NodeMapContainer> q = new Queue<NodeMapContainer>();
            q.Enqueue(new NodeMapContainer(0, root));
            while (q.Count != 0)
            {
                var node = q.Dequeue();
                res[node.currentLevel] = node.value.key;
                if (node.value.left != null) q.Enqueue(new NodeMapContainer(node.currentLevel -1, node.value.left));
                if (node.value.right != null) q.Enqueue(new NodeMapContainer(node.currentLevel + 1, node.value.right));
            }
        }


        public static void PrintTopViewLevelOrderTraversal(Node root, Dictionary<int, int> dic)
        {
            if (root == null) return;
            Queue<NodeMapContainer> q = new Queue<NodeMapContainer>();
            q.Enqueue(new NodeMapContainer(0, root));
            while(q.Count != 0)
            {
                var node = q.Dequeue();
                if (!dic.ContainsKey(node.currentLevel))
                {
                    dic[node.currentLevel] = node.value.key;
                }
                if (node.value.left != null) q.Enqueue(new NodeMapContainer(node.currentLevel - 1, node.value.left));
                if (node.value.right != null) q.Enqueue(new NodeMapContainer(node.currentLevel + 1, node.value.right));
            }
        }

        public static void PrintTopView(Node root, Dictionary<int, MapContainer> res, int currentLevel, int horizontalDistance)
        {
            if (root == null) return;
            if (res.ContainsKey(horizontalDistance))
            {
                var currentLevelMap = res[horizontalDistance]; 
                if(currentLevel <= currentLevelMap.currentLevel)
                {
                    var updateValue = new MapContainer(currentLevel, root.key);
                    res[horizontalDistance] = updateValue;
                }
            }
            else
            {
                var r = new MapContainer(currentLevel, root.key);
                res[horizontalDistance] = r;
            }
            PrintTopView(root.left, res, currentLevel +1, horizontalDistance - 1);
            PrintTopView(root.right, res, currentLevel + 1, horizontalDistance + 1);
        }

        //invert/ mirror tree
        public static void InvertTree(Node root)
        {
            if (root == null) return;
            InvertTree(root.left);
            InvertTree(root.right);

            // alternate left and right child
            Node r = root.right;
            root.right = root.left;
            root.left = r;
        }

        // two ways 
        // n2 and n

        public static bool NodeHas1ChildBST(int [] preOrder)
        {
            int len = preOrder.Length;
            int minSoFar = preOrder[len-1];
            int maxSoFar = preOrder[len - 1];
            for(int i = len -2; i >= 0; i--)
            {
                int current = preOrder[i];
                // for 1 child per node in bst, have to be either on left or right(without creating a tree)
                // If it is on the right, all the children should be greator than the current
                // If it is the left all the children should be less than the current

                if(!(current < minSoFar || current > maxSoFar))
                {
                    return false;
                }
                minSoFar = Math.Min(current, minSoFar);
                maxSoFar = Math.Max(current, maxSoFar);
            }
            return true;
        }

        public static bool AreIdentical(Node t1, Node t2)
        {
            if (t1 == null && t2 == null)
            {
                return true;
            }
            if((t1 == null && t2 != null) || (t2 == null && t1 != null))
            {
                return false;
            }

            if (!(t1.key == t2.key && AreIdentical(t1.left, t2.left))) return false;
            if (!(t1.key == t2.key && AreIdentical(t1.right, t2.right))) return false;
            return true;

        }

        public static void NodePerLevel(Node root)
        {
            if (root == null) return;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                int qLevelSize = q.Count;

                for (int i = 0;i < qLevelSize; i++)
                {
                    var node = q.Dequeue();

                    Console.Write(" ,"+node.key);
                    if (node.left != null) 
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                }
                Console.WriteLine();
                Console.WriteLine("Level Complete");
            }
        }

        public static bool IsCousins(Node root, int x, int y)
        {
            // if the same false
            // if sibling false
            if (x == y) return false;
            if (Sibling(root, x, y)) return false;
            //Check node level
            int l = GetNodeLevel(root, x);

            int l2 = GetNodeLevel(root, y);

            if (l == l2) return true;
            return false;
        }

        private static bool Sibling(Node root, int x, int y)
        {
            if (root == null) return false;
            if ((root.left != null && root.left.key == x && root.right.key == y) ||( root.right != null && root.right.key == x && root.left.key == y))
            {
                return true;
            }
            else
            {
                if (Sibling(root.left, x, y)) return true;
                if(Sibling(root.right, x, y)) return true;
            }
            
            return false;
        }
        private static int  GetNodeLevel(Node root, int key)
        {
            int count = 0;
            if (root == null) return count;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int levelSize = q.Count;
                count++;
                for (int i = 0; i < levelSize; i++)
                {
                    var node = q.Dequeue();
                    if (key == node.key) return count;
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);

                }
            }
            return count;
        }

        public static int DeepestOddLeafSize(Node root, int currentLevel)
        {
            if (root == null) return 0;
            if (root.left == null && root.left == null && currentLevel % 2 != 0) return currentLevel;
            return Math.Max(DeepestOddLeafSize(root.left, currentLevel+1), DeepestOddLeafSize(root.right, currentLevel+1));

        }

        private static Node RemoveSumNodeLessKTree()
        {
            Node root = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            Node n7 = new Node(7);
            Node n8 = new Node(8);
            Node n9 = new Node(9);
            Node n10 = new Node(10);


            root.left = n2;
            root.right = n3;

            n3.left = n4;
            n3.right = n5;

            n4.left = n6;

            n5.right = n7;

            n6.right = n8;

            n7.left = n9;

            n9.left = n10;



            return root;
        }

        private static Node TopViewTree()
        {
            Node root = new Node(1);
            Node n1 = new Node(2);
            Node n2 = new Node(3);
            Node n3 = new Node(4);
            Node n4 = new Node(5);
            Node n5 = new Node(6);
            Node n6 = new Node(7);
            Node n7 = new Node(8);
            Node n8 = new Node(9);
            Node n9 = new Node(10);
            Node n10 = new Node(11);

            root.left = n1;
            root.right = n2;

            n1.left = n3;
            n1.right = n4;

            n2.left = n5;
            n2.right = n6;

            n3.right = n7;

            n4.left = n8;

            n5.right = n9;

            n6.right = n10;

            return root;
        }
        public static Node createSampleTree1()
        {
            Node root = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            Node n7 = new Node(7);
            Node n8 = new Node(8);
            Node n9 = new Node(9);
            Node n10 = new Node(10);

            root.left = n2;
            root.right = n3;

            n3.left = n4;
            n3.right = n5;

            n4.left = n6;

            n5.right = n7;

            n6.right = n8;

            n7.left = n9;

            n9.left = n10;
            return root;
        }
        private static void SumLeft(Node root, int[] sum)
        {
            if (root == null) return;

            if (IsLeafNode(root.left))
            {
                sum[0] += root.left.key;
            }
            SumLeft(root.left, sum);
            SumLeft(root.right, sum);
        }
        private static bool IsLeafNode(Node root)
        {
            if (root == null) return false;
            if (root.left == null && root.right == null) return true;
            return false;
        }
        public static List<int> LeftSideViewRecursion(Node root,  List<int>l, int currentLevel)
        {
            //List<int> l = new List<int>();
            if (root == null) return l;
            if(currentLevel > l.Count)
            {
                l.Add(root.key);
            }
            LeftSideViewRecursion(root.left, l, currentLevel +1);
            LeftSideViewRecursion(root.right,l,  currentLevel + 1);
            return l;
        }
        public static int GetMinimunHeight(Node root)
        {
            if (root == null) return 0;

            if (root.left == null && root.right == null) return 1;

            int left = root.left != null ? GetMinimunHeight(root.left) : int.MaxValue;// prevent when the tree is skweed on  side
            int right = root.right != null ?  GetMinimunHeight(root.right) : int.MaxValue;
            return 1+ Math.Min(left, right);
        }
        public static void TestReturn1()
        {
            List<int> l = new List<int>();
            for(int i = 0; i <8; i++)
            {
                l.Add(i);
                if (i == 5) return;
            }
            TestReturn2(l);
        }
        public static void TestReturn2(List<int> list)
        {
            foreach (int i in list)
            {
                Console.WriteLine( i);
            }

        }
        private static Node CreateTree()
        {
            Node root = new Node(0);
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            Node n7 = new Node(7);
            Node n8 = new Node(8);

            root.left = n1;
            root.right = n2;

            n1.left = n3;
            n1.right = n4;

            n2.left = n5;

            n3.right = n6;

            n5.right = n7;

            n6.right = n8;

            return root;
        }

        public static void PrintAllPathsToLeafsHelper(Node root)
        {
            if (root == null) return;
            PrintAllPathsToLeafs(root, new List<int>());
        }
        public static void PrintAllPathsToLeafs(Node root, List<int> res)
        {
            if (root == null) return;
            res.Add(root.key);
            if (root.left == null && root.right == null)
            {
                Console.WriteLine("Paths To Leaf: "+string.Join(",", res));
                //res = new List<int>();
                return;
            }
            PrintAllPathsToLeafs(root.left, new List<int>(res));
            PrintAllPathsToLeafs(root.right, new List<int>(res));
        }
        public static List<int> NodesWithNoSiblings(Node node)
        {
            List<int> list = new List<int>();
            if (node == null) return list;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);

            while(q.Count != 0)
            {
                var n = q.Dequeue();
                
                if (n.left == null && n.right != null)
                {
                    list.Add(n.right.key);
                }
                else if (n.right == null && n.left != null)
                {
                    list.Add(n.left.key);
                }
                if (n.left != null) q.Enqueue(n.left);
                if (n.right != null) q.Enqueue(n.right);
            }

            return list;
        }



        public static IList<int> PrintRightViewRecursion(Node node, List<int> list, int currentLevel)
        {
            // Base case
            if (node == null) return list;
            if(list.Count < currentLevel)
            {
                list.Add(node.key);
                currentLevel = list.Count;
            }
            PrintRightViewRecursion(node.right, list, currentLevel + 1);
            PrintRightViewRecursion(node.left, list, currentLevel + 1);
            return list;
        }
        public static IList<int> RightSideViewWorked(Node root)
        {
            IList<int> list = new List<int>();
            if (root == null) return list;
            Queue<NodeAndLevel> q = new Queue<NodeAndLevel>();
            int maxLevel = -1;
            q.Enqueue(new NodeAndLevel(root, 0));
            while (q.Count != 0)
            {
                var node = q.Dequeue(); 
                if( node.level > maxLevel)
                {
                    list.Add(node.node.key);
                    maxLevel += 1;
                }
                // Get the right node in first
                if (node.node.right != null) q.Enqueue(new NodeAndLevel(node.node.right, node.level + 1));
                if (node.node.left != null) q.Enqueue(new NodeAndLevel(node.node.left, node.level+1));
                
            }
            return list;
        }

        public static IList<int> RightSideView(Node root)
        {
            IList<int> list = new List<int>();
            if (root == null) return list;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                for (int i = 0; i < q.Count; i++)
                {
                    var node = q.Dequeue();
                    if (i == 0)
                        list.Add(node.key);

                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
            }
            return list;
        }

        public static void PrintTreeLeftView(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            Queue<int> q2 = new Queue<int>();
            q2.Enqueue(root.key);
            if(root != null)
            {
                q.Enqueue(root);

                while(q.Count != 0)
                {
                    ////if(q2.Count != 0)
                    ////{
                    ////    Console.WriteLine("Right View :" + q2.Peek());
                    ////}
                   
                    for(int i = 0; i < q.Count; i++)
                    {
                        if(i == 0)
                            Console.WriteLine("Right View :" + q.Peek().key);
                        var node = q.Dequeue();

                        // If it is right=>left first If it is left, right first
                        // below is wrong
                        if (node.left != null)
                        {
                            q.Enqueue(node.left);
                            q2.Enqueue(node.left.key);
                        }

                        if (node.right != null)
                        {
                            q.Enqueue(node.right);
                            q2.Enqueue(node.right.key);
                        }

                    }
                    
                        

                }
            }
        }
    }

    public class AVLTreeNode
    {
        public int key;
        public AVLTreeNode left;
        public AVLTreeNode right;

        public int height;

        public AVLTreeNode(int value)
        {
            key = value;
        }
        
    }

    public class Tree
    {
        public Node root;
        public Tree(int value)
        {
            root = new Node(value);
        }
        public Tree()
        {
           
        }


        public AVLTreeNode InsertAVL(AVLTreeNode root, int value)
        {
            if (root == null) return new AVLTreeNode( value);
            if (root.key > value)
            {
                root.left = InsertAVL(root.left, value);
            }
            
            if(root.key < value)
            {
                root.right = InsertAVL(root.right, value);
            }
            root.height = GetAVLNodeHeight(root);

            // check if the tree is balanced and balance it if needed
            int balanceFactor = BalanceFactor(root);
            if (!IsBalance(balanceFactor))
            {
                // Check if the tree is heavy on the left
                // for right rotation
                if(balanceFactor > 1)
                {
                    // check if it is left left insert key < node.key
                    // have to be less than the root value
                    if(value < root.left.key)
                    {
                        root = RightRotation(root);
                    }
                    else
                    {
                        root.left = LeftRotation(root.left);
                        root = RightRotation(root);
                    }
                }

                // For Insertion on the right
                if(balanceFactor < -1)
                {
                    // Confirm Right Right insert
                    if(value > root.right.key)
                    {
                        root = LeftRotation(root);
                    }
                    // confirm right left insertion  need 2 rotations
                    else
                    {
                        root.right = RightRotation(root.right);
                        root = LeftRotation(root);
                    }
                }
            }

            return root;
        }

        public AVLTreeNode RightRotation(AVLTreeNode node)
        {
            if (node == null) return node;
            AVLTreeNode beta = node.left;
            AVLTreeNode betaRight = beta.right;

            // Now swap
            beta.right = node;
            node.left = betaRight;

            // update the heights
            // update height of the root then beta as beta uses height of the node to get it height...node is below beta
            node.height = GetAVLNodeHeight(node);
            beta.height = GetAVLNodeHeight(beta);
            return beta;
        }

        public AVLTreeNode LeftRotation(AVLTreeNode node)
        {
            if (node == null) return node;
            AVLTreeNode beta = node.right;
            AVLTreeNode betaLeft = beta.left;

            // Swap Nodes
            beta.left = node;
            node.right = betaLeft;

            node.height = GetAVLNodeHeight(node);
            beta.height = GetAVLNodeHeight(beta);
            return beta;

        }

        public bool IsBalance(int balaceFactor)
        {
            return ((balaceFactor >= -1 && balaceFactor <= 1));
            
        }
        public int BalanceFactor(AVLTreeNode node)
        {
            if (node == null) return 0;
            return GetAVLNodeHeight(node.left) - GetAVLNodeHeight(node.right);
        }

        public int GetAVLNodeHeight(AVLTreeNode root)
        {
            if (root == null) return -1;
            int leftHeight = GetAVLNodeHeight(root.left);
            int rightHeight = GetAVLNodeHeight(root.right);

            return Math.Max( leftHeight, rightHeight) +1;
        }
        public string InorderTraversal(Node root, string res)
        {
            // Left Root Right
           if(root != null)
            {
                if (root.left != null)
                {
                    res = InorderTraversal(root.left, res);
                }
                res += "," + root.key;
                if (root.right != null)
                {
                    res = InorderTraversal(root.right, res);
                }
            }

            return res;
        }

        public string PreOrderTraversal(Node root, string res)
        {
            if (root != null)
            {
                res += "," + root.key;
                if (root.left != null)
                    res = PreOrderTraversal(root.left, res);
                if (root.right != null)
                    res = PreOrderTraversal(root.right, res);
            }
            return res;
        }

        public string PostOrderTraversal(Node root,string res)
        {
            if(root != null)
            {
                if(root.left != null)
                    res = PostOrderTraversal(root.left, res);
                if(root.right != null)
                    res = PostOrderTraversal(root.right, res);
                res += ","+root.key;

            }
            return res;
        }

        public string LevelOrderTraversal(Node root, string res)
        {
            if(root != null)
            {
                Queue<Node> q = new Queue<Node>();
                q.Enqueue(root);

                while(q.Count != 0)
                {
                    var node = q.Dequeue();
                    res += "," + node.key;
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                }

            }
            return res;
        }

        public int TreeSize(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            Stack<int> s = new Stack<int>();
            if(root == null)
            {
                return 0;
            }
            else
            {
                q.Enqueue(root);
                
                while(q.Count != 0)
                {
                    var node = q.Dequeue();
                    s.Push(node.key);
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);

                }
            }

            return s.Count;
        }

        // Nodes considered not edges
        public int Height(Node root)
        {
            if(root != null)
            {
                //int leftHeight = 0; int rightHeight = 0;
                //if (root.left != null)
                //{
                //    int l = Height(root.left);

                //}

                //if (root.right != null)
                //     int rightHeight = Height(root.right);
                int leftHeight = Height(root.left);
                int rightHeight = Height(root.right);
                return 1+ Math.Max(leftHeight, rightHeight);
            }
            else
            {
                return 0;
            }
        }

        public void Insert(Node node,int key)
        {
            if(node != null)
            {
                if(node.key >  key)
                {
                    if(node.left == null)
                    {
                        node.left = new Node(key);
                    }
                    else
                    {
                        Insert(node.left, key);
                    }
                }else if (node.key < key)
                {
                    if(node.right == null)
                    {
                        node.right = new Node(key);
                    }
                    else
                    {
                        Insert(node.right, key);
                    }
                }
                //if(node.left != null && node.key > key)
                //{
                //    Insert(node.left, key);
                //}else if (node.right != null && node.key < key)
                //{
                //    Insert(node.right, key);
                //}else if(node.left == null && node.key > key)
                //{
                //    node.left = new Node(key);
                //}else if(node.right == null && node.key < key)
                //{
                //    node.right = new Node(key);
                //}
            }
            else
            {
                root = new Node(key);
            }
        }

        public bool IsBTS(Node root, int min, int max)
        {
            if (root == null) return true;
            if(!(root.key > min && root.key < max))
            {
                return false;
            }
            return IsBTS(root.left, min, root.key) && IsBTS( root.right, root.key, max);
        }

    }

    public class NodeMapContainer
    {
        public int currentLevel;
        public Node value;
        public NodeMapContainer(int level, Node v)
        {
            currentLevel = level;
            value = v;
        }
    }

    // Map
    public class MapContainer {
        public int currentLevel;
        public int value;
        public MapContainer(int level, int v)
        {
            currentLevel = level;
            value = v;
        }
    }

    /// TreeNode
    /// 
    public class Node
    {
        public Node left;
        public Node right;
        public int key;

        public Node(int value)
        {
            key = value;
            left = null;
            right = null;
        }
    }
    public class NodeAndLevel
    {
        public int level;
        public Node node;
        public NodeAndLevel(Node newNode, int newLevel)
        {
            node = newNode;
            level = newLevel;
        }
    }
    public class DDLinekdList
    {
        public DDLinekdList prev;
        public DDLinekdList next;
        int val;
        public DDLinekdList(int x)
        {
            val = x;
            prev = null;
            next = null;
        }
    }

    public class TrieOperatons
    {
        public TrieNode root;
        public TrieOperatons()
        {
            root = new TrieNode('@');
        }

        public void Insert(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                TrieNode temp = node.trieNodes[c - 'a'];
                if(temp == null)
                {
                    TrieNode newNode = new TrieNode(c);
                    node.trieNodes[c - 'a'] = newNode;
                    temp = newNode;
                }
                node = temp;
            }
            node.IsLeaf = true;
        }

        public bool Search(string word)
        {
            TrieNode node = root;
            foreach(char  c in word.ToLower())
            {
                TrieNode temp = node.trieNodes[c - 'a'];
                if(temp == null)
                {
                    return false;
                }
                else
                {
                    node = temp;
                }
            }
            return node.IsLeaf; 
        }

        public bool Delete(string word, TrieNode node, int level, int size)
        {
            bool isDeleted = false;
            // check if node is null
            if (node == null)
            {
                return isDeleted;
                // the last level
            } else if (level == size)
            {
                // check if it have children
                if (hasChildren(node))
                {
                    // umark it as a leaf
                    // also set deleted to false
                    node.IsLeaf = false;
                    isDeleted = false;
                }
                else
                {
                    node = null;
                    isDeleted = true;
                }

            }
            else
            {
                var childNode = node.trieNodes[word[level] - 'a'];
                bool childDeleted = Delete(word, childNode, level + 1, size);

                if (childDeleted)
                {
                    // making child pointer null as they av been deleted
                    node.trieNodes[word[level] - 'a'] = null;

                    if (node.IsLeaf || hasChildren(node))
                    {
                        isDeleted = false;
                    }
                    else
                    {
                        isDeleted = true;
                        node = null;
                    }
                }
                else
                {
                    isDeleted = false;
                }

            }
            return isDeleted;
        }

        public bool hasChildren(TrieNode node)
        {
            if (node == null) return false;

            foreach(var c in node.trieNodes)
            {
                if (c != null) return true;
            }
            return false;
        }
    }

    public class TrieNode
    {
        public char c;
        public TrieNode[] trieNodes;
        public bool IsLeaf;

        public TrieNode(char v)
        {
            c = v;
            trieNodes = new TrieNode[26];
        }
    } 

    public class MinHeap
    {
        private List<int> list;
        public MinHeap()
        {
            list = new List<int>();
        }

        // Done on delete
        ////public HeapifyDown()
        ////{

        ////}
        ///
        public void Delete(int value)
        {
            if (list.Contains(value))
            {
                if (list[0] == value)
                {
                    list.Remove(value);
                }
            }
        }

        public void Insert(int value)
        {
            list.Add(value);
            int len = list.Count - 1;
            for(int i = len; i >= 0; i--)
            {
                if( i-1 >=0 && list[i-1] > list[i])
                {
                    int smaller = list[i];
                    list[i] = list[i - 1];
                    list[i - 1] = smaller;
                }
            }
        }

        public override string ToString()
        {
            return string.Join(",", list);
        }
    }
}
