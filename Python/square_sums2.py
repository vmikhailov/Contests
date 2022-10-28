import sys
import logging
from math import sqrt

from datetime import datetime

logger = logging.getLogger(__name__)
logger.setLevel(level=logging.DEBUG)
stdout_log = logging.StreamHandler(sys.stdout)
data_log = logging.FileHandler('out.log', encoding="UTF-8")
stdout_log.setLevel(logging.INFO)
data_log.setLevel(logging.INFO)
logger.addHandler(stdout_log)
logger.addHandler(data_log)


def find_a_path(graph, start, path=None):
    if path is None:
        path = []
    path = path + [start]
    if len(graph) == len(path):
        return path
    if start not in graph:
        return None
    for node in graph[start]:
        if node not in path:
            new_path = find_a_path(graph, node, path)
            if new_path:
                return new_path
    return None


def all_sums(max):
    i = 1
    connections = {}
    while i <= max:
        connections[i] = []
        for j in range(1, i):
            if sqrt(i + j).is_integer():
                connections[i] += [j]
                connections[j] += [i]
        found = None
        start_time = datetime.now()
        for start_point in range(1, i + 1):
            found = found or find_a_path(connections, start_point)
            if found:
                break
        time_to_run = datetime.now() - start_time
        logger.info("{} ({} seconds): {}".format(i, time_to_run.total_seconds(), found))
        i += 1