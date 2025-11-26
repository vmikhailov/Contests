package main

// reverseVowels returns a new string where only the vowels in s are reversed.
// It operates on runes so multibyte UTF-8 characters are handled correctly.
func reverseVowels(s string) string {
	r := []rune(s)
	if len(r) < 2 {
		return s // nothing to do for empty or single-rune strings
	}
	i, j := 0, len(r)-1
	for i < j {
		for i < j && !isVowel(r[i]) {
			i++
		}
		for i < j && !isVowel(r[j]) {
			j--
		}
		// swap vowels
		r[i], r[j] = r[j], r[i]
		i++
		j--
	}
	return string(r)
}

var vowelSet = map[rune]struct{}{
	'a': {}, 'e': {}, 'i': {}, 'o': {}, 'u': {},
	'A': {}, 'E': {}, 'I': {}, 'O': {}, 'U': {},
}

func isVowel(r rune) bool {
	_, ok := vowelSet[r]
	return ok
}
