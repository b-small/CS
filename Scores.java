package game;

import java.io.*;
import java.util.*;

/**
 *
 * @author team Cluster
 *
 */

public class Scores {

	private List<StatusLine> scores;

	public Scores() {
		setList();
	}

	public void setList() {
		scores = StatusLine.getSaveObjects();
	}

	public String[] loadScores(String currentPath) throws IOException {
		FileReader fr = new FileReader(currentPath);
		BufferedReader br = new BufferedReader(fr);

		int numberOfLines = 0;

		while (br.readLine() != null) {
			numberOfLines++;
		}

		String[] playerInfoRead = new String[numberOfLines];
		for (int i = 0; i < numberOfLines; i++) {
			playerInfoRead[i] = br.readLine();
		}
		br.close();
		return playerInfoRead;
	}

	public void addScore(StatusLine status) {
		scores.add(status);
	}

	public void saveScores() {

		try {
			BufferedWriter out = new BufferedWriter(
					new FileWriter("scores.txt"));
			for (int i = 0; i < scores.size(); i++) {
				out.write(scores.get(i).toString());
				out.newLine();
			}
			out.flush();
			out.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
