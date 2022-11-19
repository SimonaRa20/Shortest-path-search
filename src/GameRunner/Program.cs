using GameRunner;

ISolution solution = new Solution();
IGame game = new Game(solution);

var result = game.Run(@"TestData\map1.txt");