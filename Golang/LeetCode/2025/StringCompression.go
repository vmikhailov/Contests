package main

import "strconv"

func compress(chars []byte) int {
	r := make([]byte, 0)

	for i := 0; i < len(chars); i++ {
		j := i + 1
		for j < len(chars) && chars[i] == chars[j] {
			j++
		}

		r = append(r, chars[i])

		if j-i > 1 {
			count := strconv.Itoa(j - i)
			r = append(r, []byte(count)...)
		}
		i = j - 1
	}

	copy(chars, r)
	return len(r)
}
