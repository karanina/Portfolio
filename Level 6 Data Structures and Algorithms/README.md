# Yahtzee Game - Analysis & Commentary

## Introduction

I approached the creation of this game by first attempting to run the game via the Console, before designing and implementing a User Interface (UI) using SFML. I chose to use two different data structures, a Linked List to store the results of each round, and a Binary Search Tree to store the different scoring categories available in the game. In addition to these classes (and their associated node classes), I also created a Dice class (which contains information about the dice, and simulates dice rolls using randomised data), a Scoring category (which holds the different scoring methods used for each scoring category), a GameDisplay class (which uses SFML and runs the game loop), and a MessageDisplay class (which communicates information to the players when they request it, or try to break any of the game rules).

## Code Implementation

### ScoreNode & ScoreLinkedList Classes

The Linked List utilises the *ScoreNode* class as it's node class, and is itself implemented in the *ScoreLinkedList* class. It contains the following global variables:
+ *next* - data type: *ScoreNode* - a link to the next *ScoreNode* in the *ScoreLinkedList*.
+ *roundScore* - data type: *int* - the score for the round.
+ *roundDiceTotals* - data type: *int[,]* - a two dimensional array containing the number of ones rolled, the number of twos rolled... the number of sixes rolled.
+ *roundCategory* - data type: *ScoreCategoryBinaryTree.ScoringCategories* - an Enum found in the *ScoreCategoryBinaryTree* class used to make it easier to read the code relating to scoring categories used and selected.

As well as containing the nodes from the *ScoreNode* class, The *ScoreLinkedList* class keeps track of the below variables in its head:
+ *numberOfRounds* - data type: *int* - the number of rounds played in the game thus far.
+ *maxRounds* - data type: *int* - this is a constant variable of 13. A maximum of 13 rounds can be played in the game.
+ *upperSectionScore* - data type: *int* - the total score from categories in the "Upper Section". The "Upper Section" is on the left hand side of the game board, and calculates the total of a given dice side (for example if you select 1's, the number of 1's rolled is added up).
+ *lowerSectionScore* - data type: *int* - the total score from categories in the "Lower Section". The "Lower Section* is on the right hand side of the game board, and contains the special scoring categories such as "3 of a Kind" and "Full House".
+ *totalScore* - data type: *int* - the *totalScore* adds together the *upperSectionScore* and the *lowerSectionScore*.
+ *hasYahtzee* - data type: *bool* - this variable keeps track of whether or not the Yahtzee category has been scored in, as if there are any further Yahtzees in a game, each one is awarded an additional 100 points to their score.
+ *hasUpperSectionBonus* - data type: *bool* - similarly, if a player has already achieved 63 points in the Upper Section, they receive 35 bonus points to add to their score.

The main methods associated with this class include:
+ *AddNode* - which takes in the the *roundDiceTotals* and *roundCategory* variables, uses the *ContainsNode* method to make sure the category has not already been scored in, decide whether any bonus' are required, and increments the *numberOfRounds*, and applicable score sections in the head. It returns a boolean value confirming its creation.
+ *ContainsNode* - takes in a *roundCategory* variable, and checks whether it is already in the List, and therefore has already been scored in, returning a boolean value.
+ *RetrieveScore* - again, takes in a *roundCategory* variable and retrieves the *roundScore* attached to that particular node. This is used in the *GameDisplay* class's *Update* method to update values to the UI.
+  *EmptyList* - this method is called when a game is underway, or finished, and the player wishes to begin a new game. It severs the link to the head node and resets the global variables to 0.

No other methods were required to make this game as there is no "Undo" option.

The *ScoreLinkedList* and the *ScoreNode* classes were both relatively easy to implement. The nodes don't need to be kept in any particular order in the List, but the program does need to be able to traverse them without removing them from the list, which is why I chose a Linked List rather than a Stack. Traversing a Linked List (as in the *ContainsNode* and *RetrieveScore* methods) has a worst case time complexity of O(n). However, given that only 13 nodes (the maximum number of rounds) would ever need to be created, I decided to favour simplicity of implementation over time and space complexity considerations (a Linked List has a worst case space complexity of O(n)). The *AddNode* and *EmptyList* methods both have a worst case time complexity of O(1), making the *AddNode* operation generally speedier than with a Binary Search Tree. An *EmptyList* method that severed the root of a Binary Search Tree would have the same time complexity, as that of a Linked List.

One of the advantages of a Linked List is that it is a dynamic data structure. A Linked List is a series of nodes in memory with a reference to the next node (and with Doubly Linked Lists, the previous one), therefore it does not require consecutive space in memory like an array. This makes for efficient memory allocation, which can grow or shrink as required, whereas the space for an array needs to be declared (or "booked") upon it's creation, and any unused space inside of the array cannot be released for use by other parts of the program. However, a Linked List does require more space than an array, as it has to keep a pointer to the next node, as mentioned previously. Traversal in a Linked List takes longer than in an array or a list, as the program needs to step through each node to get to its target, whereas an array or list can simply be indexed, and randomly accessed, if the target's position is known. 


### Scoring Class

The *Scoring* class is not one of the two chosen data structures for this project, but it plays an important part in the *ScoringCategoryBinaryTree* and *ScoringCategoryNode* classes.

The *Scoring* class contains all the different calculations required to calculate the score for each category in the game, as well as the values and conditions for any bonus' given, as below:
+ *roundTotal* - data type: *int* - the total score calculated for the round being completed.
+ *yahtzeeBonus* - data type: *int* - the number of points given for each subsequent Yahtzee after the first one has been attained.
+ *upperSectionBonusRequired* - data type: *int* - the number of points achieved in the Upper Section before the player receives the bonus.
+ *upperSectionBonus* - data type: *int* - the number of points given to the player upon being eligable for the Upper Section Bonus.

### ScoreCategoryNode & ScoreCategoryBinaryTree Classes

The *ScoreCategoryNode* and the *ScoreCategoryBinaryTree* were both more difficult to implement than the Linked List, due in large part to making use of Delegates (which I have no experience with), which hold references to the methods of the *Scoring* class, but also due to the need to retain a link to the parent as well as the children of each node. As I created a Balanced Binary Tree by using a recursive Divide and Conquer algorithm through the *PopulateNodes()*, *CreateRoot()* and *InsertNode()* methods, it became that much more complex for me.

The *ScoreCategoryBinaryTree* is used here as a sort of "reference library" (a library in the literary sense). It is created in its entirety upon starting the program, and then traversed throughout the game whenever a node needs to be added to the *ScoreLinkedList* class. As such, given that it would only ever contain 13 nodes (there are 13 scoring categories), my primary concern was traversal speed. In a worst case scenario, a search on a Binary Search Tree has a time complexity of O(n). However by creating a Balanced Binary Search Tree, I was able to achieve a time complexity of O(log(n)) to make traversal faster.

The head of the *ScoreCategoryBinaryTree* creates an Enum data type called *ScoringCategories* which is used to make the code easier to work with. And as an Enum can be explicitly converted to an int, it constituted an ideal way to interact with the different scoring calculation methods. The Enums were then placed in an array called *scoringCategories* so they could be iterated over. 

The head also defines the signature of a delegate type called *ScoringDelegate* which takes in a 2 dimensional array of integers(int[,]) and returns an integer. A *ScoringDelegate* for each of the scoring calculation methods is then created, and in the PopulateScoringMethods() method, given the reference of each of the scoring calculation methods, and added to the ScoringFunctions list of delegates, for future iteration. As the Binary Search Tree was created as a Balanced Binary Search Tree, the PopulateScoringMethods() method has a time complexity of O(log n).

Other metadata held by the *ScoreCategoryBinaryTree* include:
+ *root* - Data type: *ScoreCategoryNode* - a reference to the first node of the *ScoreCategoryBinaryTree*.
+ *maxNodes* - Data type: *int* - the maximum number of nodes the *ScoreCategoryBinaryTree* may contain.
+ *totalNodes* - Data type: *int* - the current number of nodes populating the *ScoreCategoryBinaryTree*.

As well as the methods used to create the Binary Search Tree (primarily the *PopulateNodes()*, *PopulateScoringMethods()*, *CreateRoot()* and *InsertNode()* methods), the other method used by the *ScoreCategoryBinarySearchTree* class is the *SearchScoringDelegates()* method. This method performs a recursive, pre-order traversal on the nodes of the Binary Search Tree looking for the name of the category chosen by the player to retrieve it's method to use in the calculation of the score for the round. As mentioned before, this traversal search method has a worst case time complexity of O(log n). 

But no matter what time complexity I am able to achieve, a Balanced Binary Search Tree still has a space complexity of O(n).

A Balanced Binary Search Tree is therefore faster to traverse than a Linked List, but not always faster to add a node to, as while the Linked List can just push a node to the head position, a Binary Search Tree needs to traverse a path to a leaf node and insert the node there, giving it a time complexity of O(log n) vs a Linked List's O(1) - as implemented here. Like a Linked List, a Binary Search Tree is also efficient in terms of memory allocation, however, it needs to hold three references to other nodes, as opposed to a (Singly) Linked List's one, making it less efficient in terms of required memory.

It should be noted that each *ScoreCategoryNode* holds the following variables:
+ *parent* - data type: *ScoreCategoryNode* - a reference to the parent of the current node.
+ *left* - data type: *ScoreCategoryNode* - a reference to the left hand child of the current node.
+ *right* - data type: *ScoreCategoryNode* - a reference to the right hand child of the current node.
+ *name* - data type: *ScoreCategoryBinaryTree.ScoringCategories* - an Enum found in the *ScoreCategoryBinaryTree* class used to make it easier to read the code relating to score categories used and selected.
+ *method* - data type: *Delegate* - a reference to the method of calculation originating in the *Scoring* class.

## Real World Applications

Obviously, the first real world application I can think of for a Linked List and a Binary Search Tree would be this program, or other sorts of interactive games. More broadly, a Linked List could be used any time two objects, or pieces of data, need to be connected together via a third. For example, the *previous page* and *next page* functions in a web browser (conneted via the *current page*), or a device which plays music. Afterall, what is a playlist, but the implementation of a Linked List?

A Binary Search Tree can be used (as displayed here) for storing sorted information. If the information is in order, it allows the program to reduce the amount of time taken to search for a particular piece of data. As such, it is also useful for indexing and multi-level indexing. These trees are also often used in 3D game engines to decide which objects should be rendered, as opposed to just rendering every object in the game (which takes up more space and time).

## Bibliography
+ https://afteracademy.com/blog/binary-search-tree-introduction-operations-and-applications *retrieved on 13th June 2021*
+ https://www.bigocheatsheet.com/ *retrieved on 17th June 2021*
+ https://dev.to/phuctm97/2-min-codecamp-binary-search-tree-and-real-world-applications-58cj *retrieved on 13th June 2021*
+ https://www.javatpoint.com/binary-search-tree *retrieved on 17th June 2021*
+ https://www.geeksforgeeks.org/applications-of-linked-list-data-structure/ *retrieved on 13th June 2021*
+ https://www.geeksforgeeks.org/advantages-and-disadvantages-of-linked-list/ *retrieved on 13th June 2021*
+ https://stackoverflow.com/questions/41054981/what-is-the-time-complexity-of-searching-in-a-binary-search-tree-if-the-tree-is *retrieved on 17th June 2021*

