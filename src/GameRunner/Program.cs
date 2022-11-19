using GameRunner;

ISolution solution = new Solution();
IMapValidation validation = new MapValidation(solution);
IGame game = new Game(solution, validation);

var result = game.Run(@"TestData\map1.txt");