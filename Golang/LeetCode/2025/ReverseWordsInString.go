package main

import "strings"

func reverseWords(s string) string {
	words := splitSkipEmpty(s, " ")

	reverse(words)

	return strings.Join(words, " ")
}

func reverse(words []string) {
	i, j := 0, len(words)-1

	for i < j {
		words[i], words[j] = words[j], words[i]
		i++
		j--
	}
}

func splitSkipEmpty(s, sep string) []string {
	parts := strings.Split(s, sep)
	// reuse backing array: keep only non-empty entries
	out := parts[:0]
	for _, p := range parts {
		if p != "" {
			out = append(out, p)
		}
	}
	return out
}
