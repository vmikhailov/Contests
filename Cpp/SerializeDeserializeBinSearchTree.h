#include <string>
#include <sstream>

using namespace std;

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;

    TreeNode(int x) : val(x), left(NULL), right(NULL) {}

    TreeNode(int x, TreeNode *l, TreeNode *r) : val(x), left(l), right(r) {}
};

class SerializeDeserializeBinSearchTree {
public:

    // Encodes a tree to a single string.
    string serialize(TreeNode *root) {
        stringstream ss;
        serialize(root, ss, true);
        return ss.str();
    }

    // Decodes your encoded data to tree.
    TreeNode *deserialize(string data) {
        if (data.size() == 0) return nullptr;
        stringstream ss = stringstream(data);
        return deserialize(ss);
    }

private:
    void serialize(TreeNode *root, stringstream &ss, bool first) {
        if (root) {
            if (!first) ss << "-";
            ss << root->val;
            serialize(root->left, ss, false);
            serialize(root->right, ss, false);
        }
    }

    TreeNode *deserialize(stringstream &ss) {
        int v;
        char c;
        TreeNode* root = nullptr;
        while(!ss.eof())
        {
            ss >> v;
            root = add(root, v);
            ss >> c;
        }

        return root;
    }

    TreeNode *add(TreeNode *root, int v) {
        if (!root) {
            return new TreeNode(v);
        }

        if (root->val > v) {
            root->left = add(root->left, v);
        } else {
            root->right = add(root->right, v);
        }

        return root;
    }
};