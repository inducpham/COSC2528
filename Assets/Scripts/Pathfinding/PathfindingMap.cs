using UnityEngine;
using System.Collections;

public class PathfindingMap : MonoBehaviour
{

		public float BorderGrow = 0.1f;
		public float TileWidth = 1f, TileHeight = 1f;
		public float CenterX = 0f, CenterY = 0f;
		private bool[,] Grid = null;
		private Vector3[,] GridVectors = null;
		private int Width = 0, Height = 0;

		public void SetSize (int width, int height)
		{
				Width = width;
				Height = height;
				Grid = new bool[width, height];
				GridVectors = new Vector3[width + 1, height + 1];
		
				//calculate the offset
				float offsetX = CenterX - Width / 2 * TileWidth;
				float offsetY = CenterY - Height / 2 * TileHeight;

				//init grid values
				for (int x = 0; x < Width; x++)
						for (int y = 0; y < Height; y++)
								Grid [x, y] = true;

				//setup grid of vectors for easy debug line
				for (int x = 0; x <= Width; x++)
						for (int y = 0; y <= Height; y++) {
								GridVectors [x, y] = new Vector3 (offsetX + x * TileWidth, 0,
			                                   offsetY + y * TileHeight);
						}
		}

		public void DisableSpace (float x, float y, float w, float h)
		{
				x += BorderGrow - CenterX + Width / 2;
				y += BorderGrow - CenterY + Height / 2;
				w -= 2 * BorderGrow;
				h -= 2 * BorderGrow;

				for (int ix = (int) x; ix < x + w; ix++)
						for (int iy = (int) y; iy < y + h; iy++)
								if (0 <= ix && ix < Width && 0 <= iy && iy < Height)
										Grid [ix, iy] = false;
		}

		//draw debug
		public void Update ()
		{
				for (int x = 0; x < Width; x++)
						for (int y = 0; y < Height; y++) {
								if (Grid [x, y]) {
										Debug.DrawLine (GridVectors [x, y], GridVectors [x + 1, y], Color.blue);
										Debug.DrawLine (GridVectors [x, y], GridVectors [x, y + 1], Color.blue);
										Debug.DrawLine (GridVectors [x + 1, y], GridVectors [x + 1, y + 1], Color.blue);
										Debug.DrawLine (GridVectors [x, y + 1], GridVectors [x + 1, y + 1], Color.blue);
								}
						}
		}
}
