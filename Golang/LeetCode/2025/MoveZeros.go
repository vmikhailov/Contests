package main

func moveZeroes(nums []int) {

	n := len(nums)
	i := 0
	j := 0

	for i < n && j < n {
		if nums[i] != 0 {
			nums[j] = nums[i]
			j++
		}
		i++
	}

	for j < n {
		nums[j] = 0
		j++
	}
}
