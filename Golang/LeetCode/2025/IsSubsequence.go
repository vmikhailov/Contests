package main

func isSubsequence(s string, t string) bool {
	sn, tn := len(s), len(t)

	i, j := 0, 0

	for i < sn && j < tn {
		if s[i] == t[j] {
			i++
		}
		j++
	}

	return i == sn
}
