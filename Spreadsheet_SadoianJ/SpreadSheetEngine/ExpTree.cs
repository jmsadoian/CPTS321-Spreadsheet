using System;
using System.Collections.Generic;
using System.Text;

namespace Cpts321
{

    public class ExpTree
    {
        private Node root;
        public static Dictionary<string, double> variable = new Dictionary<string, double>();
        public string expression { get; private set; }
        private abstract class Node
        {
            public abstract double Eval();
        }
        private class VarNode : Node
        {
            string name;
            double value;
            public VarNode(string name)
            {
                this.name = name;
                value = 0.0;
            }
            public override double Eval()
            {
                value = variable[name];
                return value;

            }
        }
        private class OpNode : Node
        {
            public Node left, right;
            char operation;
            public OpNode(char op)
            {
                operation = op;
                left = null;
                right = null;
            }
            public override double Eval()
            {
                switch (operation)
                {
                    case '+':
                        return this.left.Eval() + this.right.Eval();
                    case '-':
                        return this.left.Eval() - this.right.Eval();
                    case '*':
                        return this.left.Eval() * this.right.Eval();
                    case '/':
                        return this.left.Eval() / this.right.Eval();

                }
                return 0.0;

            }
        }
        private class ValNode : Node
        {
            double value;
            public ValNode(double value)
            {
                this.value = value;
            }
            public override double Eval()
            {
                return value;
            }
        }


        public ExpTree(string expression)
        {
            variable.Clear();
            this.expression = expression;
            ConstructTree(expression);
        }

        Node ConstructTree(string expression)
        {
            double value;
            for(int i = expression.Length - 1; i >= 0; i--)
            {
                switch(expression[i])
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        OpNode newNode = new OpNode(expression[i]);
                        if (root == null)
                            root = newNode;
                        newNode.left = ConstructTree(expression.Substring(0, i));
                        newNode.right = ConstructTree(expression.Substring(i + 1));
                        return newNode;
                        
                }
            }
            if (Double.TryParse(expression, out value))
                return new ValNode(value);
            else
                return new VarNode(expression);

        }
        public void SetVar(string varName, double varValue)
        {
            try
            {
                variable.Add(varName, varValue);
            }
            catch
            {
                variable[varName] = varValue;
            }
        }

        public double Eval()
        {
            return root.Eval();
        }
    }
}
