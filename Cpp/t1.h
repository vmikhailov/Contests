#include <iostream>
#include <vector>
#include <unordered_set>

std::vector<std::string> unique_names(const std::vector<std::string>& names1, const std::vector<std::string>& names2)
{
    auto set = std::unordered_set<std::string>();

    set.insert(names1.begin(), names1.end());
    set.insert(names2.begin(), names2.end());

    auto result = std::vector<std::string>();

    result.insert(result.end(), set.begin(), set.end());

    return result;
}
