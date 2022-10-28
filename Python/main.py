from datetime import datetime

import break_pieces
from InsaneTriangle import insane_tri_test
from InsaneTriangle import insane_tri_test2
from cheapest_path import cheapest_path_test
from slide_puzzle import slide_puzzle
import slide_puzzle_test

#
# ar = [x[:] for x in slide_puzzle_test.puzzle4]
# r = slide_puzzle(ar)
# print(r)

# t = datetime.now()
# for r in range(10):
#     cheapest_path_test.test5()
# s = (datetime.now() - t).total_seconds()
# print(s/10)


#break_pieces.test2()
insane_tri_test()
insane_tri_test2()
